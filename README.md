# Temperature Convert - 2.0-server Branch

## Branch Purpose

This branch demonstrates a **server-side ASP.NET Core MVC implementation** of temperature conversion functionality. It represents the evolution from client-side processing to a full server-side architecture, showcasing proper MVC patterns, model binding, server-side validation, and form-based processing.

## Key Features

- **Server-Side Processing**: All temperature calculations performed on the server
- **MVC Architecture**: Proper separation of concerns with Models, Views, and Controllers
- **Model Binding**: Strongly-typed views with automatic data binding
- **Form-Based Workflow**: Traditional web form submission and processing
- **Server-Side Validation**: Robust validation capabilities with ASP.NET Core
- **State Management**: Proper handling of application state through models
- **Extensible Design**: Architecture supports complex business logic and data persistence

## Architecture Overview

### Technology Stack
- **Framework**: ASP.NET Core 8.0 MVC
- **Backend**: C# with full server-side processing
- **Frontend**: Razor Views with Bootstrap 5.1
- **Data Binding**: ASP.NET Core Model Binding
- **Validation**: ASP.NET Core Data Annotations

### Architecture Pattern
```
ASP.NET Core MVC (Server-Side)
├── Models
│   ├── TemperatureConversion.cs (Data Model)
│   └── TemperatureConversionViewModel.cs (View Model)
├── Views
│   └── Index.cshtml (Strongly-typed Razor View)
└── Controllers
    └── HomeController.cs (Business Logic & Flow Control)
```

### Data Flow
1. User enters temperature value and submits form
2. ASP.NET Core model binding maps form data to view model
3. Controller processes the model and performs server-side conversion
4. Updated model is passed back to the view
5. View renders the results with both input and converted values

## How to Run

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- Any IDE that supports .NET (Visual Studio, VS Code, Rider)

### Running the Application

1. **Clone and switch to 2.0-server branch**:
   ```bash
   git clone https://github.com/d-german/temperature-convert.git
   cd temperature-convert
   git checkout 2.0-server
   ```

2. **Navigate to project directory**:
   ```bash
   cd TemperatureConvert
   ```

3. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

4. **Run the application**:
   ```bash
   dotnet run
   ```

5. **Access the application**:
   - Open browser to `https://localhost:7065` or `http://localhost:5076`
   - You'll see the temperature conversion form

### Usage Instructions
1. Enter a temperature value in either the Celsius or Fahrenheit field
2. Click the "Convert" button to submit the form
3. The page will reload with both the original value and converted result
4. The form remembers which field was last modified for proper conversion direction

## Code Highlights

### Data Models

#### TemperatureConversion.cs (Core Data Model)
```csharp
namespace TemperatureConvert.Models;

public class TemperatureConversion
{
    public double Celsius { get; set; }
    public double Fahrenheit { get; set; }
    public string LastEnteredUnit { get; set; }
}
```

#### TemperatureConversionViewModel.cs (View Model)
```csharp
namespace TemperatureConvert.Models;

public class TemperatureConversionViewModel
{
    public TemperatureConversion TemperatureConversion { get; set; }
}
```

### Enhanced HomeController.cs
```csharp
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new TemperatureConversionViewModel
        {
            TemperatureConversion = new TemperatureConversion
            {
                Celsius = 100,
                Fahrenheit = 212
            }
        });
    }

    [HttpPost]
    public IActionResult Index(TemperatureConversionViewModel model)
    {
        if (!double.IsNaN(model.TemperatureConversion.Celsius) && 
            model.TemperatureConversion.LastEnteredUnit == "Celsius")
        {
            model.TemperatureConversion.Fahrenheit = 
                model.TemperatureConversion.Celsius * 9 / 5 + 32;
        }
        else if (!double.IsNaN(model.TemperatureConversion.Fahrenheit) && 
                 model.TemperatureConversion.LastEnteredUnit == "Fahrenheit")
        {
            model.TemperatureConversion.Celsius = 
                (model.TemperatureConversion.Fahrenheit - 32) * 5 / 9;
        }

        return View(model);
    }
}
```

### Strongly-Typed Razor View
```html
@model TemperatureConvert.Models.TemperatureConversionViewModel

<form asp-controller="Home" asp-action="Index" method="post">
    <div class="input-group mb-3">
        <span class="input-group-text">Celsius</span>
        <input asp-for="TemperatureConversion.Celsius" class="form-control" 
               placeholder="Enter Celsius" 
               value="@(Model.TemperatureConversion?.Celsius.ToString() ?? "")" 
               oninput="updateLastEnteredUnit('Celsius')"/>
        <span asp-validation-for="TemperatureConversion.Celsius" class="text-danger"></span>
    </div>
    <div class="input-group mb-3">
        <span class="input-group-text">Fahrenheit</span>
        <input asp-for="TemperatureConversion.Fahrenheit" class="form-control" 
               placeholder="Enter Fahrenheit" 
               value="@(Model.TemperatureConversion?.Fahrenheit.ToString() ?? "")" 
               oninput="updateLastEnteredUnit('Fahrenheit')"/>
        <span asp-validation-for="TemperatureConversion.Fahrenheit" class="text-danger"></span>
    </div>
    <input type="hidden" asp-for="TemperatureConversion.LastEnteredUnit" id="lastEnteredUnit"/>
    <div class="d-grid">
        <button type="submit" class="btn btn-primary">Convert</button>
    </div>
</form>
```

### Key Implementation Details
- **Model Binding**: Automatic mapping between form fields and C# objects
- **Validation Support**: Built-in validation with error display
- **State Tracking**: Hidden field tracks which unit was last entered
- **Type Safety**: Strongly-typed views prevent runtime errors
- **Server Processing**: All conversion logic handled server-side

## Comparison Section

### Evolution from Main Branch

#### What Was Added
- **Complete MVC Implementation**: Full Models, Views, Controllers architecture
- **Server-Side Logic**: Temperature conversion moved to controller
- **Data Models**: Proper separation with dedicated model classes
- **Form Processing**: Traditional web form submission workflow
- **Model Binding**: Automatic data binding between views and controllers
- **Updated to .NET 8.0**: Latest framework version for optimal performance

#### Technical Changes
- **71 additions, 38 deletions** across multiple files
- **New Models**: `TemperatureConversion.cs` and `TemperatureConversionViewModel.cs`
- **Enhanced Controller**: GET and POST action methods with business logic
- **Strongly-Typed View**: Razor view with model binding and validation

### Contrasted with 1.0-ui Branch

#### Architectural Differences

| Aspect | 1.0-ui Branch | 2.0-server (This Branch) |
|--------|---------------|---------------------------|
| **Processing Location** | Client-side (Browser) | Server-side (ASP.NET Core) |
| **User Experience** | Real-time, instant conversion | Form submission required |
| **Network Traffic** | Minimal (static content only) | HTTP POST for each conversion |
| **Scalability** | Limited to client capabilities | Full server processing power |
| **Validation** | Basic JavaScript validation | Robust server-side validation |
| **State Management** | DOM-based | Model-based with proper binding |
| **Testability** | Limited (browser-dependent) | Full unit testing capabilities |
| **Maintainability** | Simple but limited | Structured MVC architecture |
| **Business Logic** | Exposed in browser | Secure server-side processing |
| **Data Persistence** | Not possible | Can easily add database support |

#### When to Choose This Approach
- **Enterprise Applications**: When you need robust, scalable architecture
- **Complex Business Logic**: Server can handle sophisticated calculations
- **Data Persistence**: Easy to add database storage and history
- **Security Requirements**: Business logic protected on server
- **Team Development**: Clear separation of concerns for larger teams
- **Testing Requirements**: Full unit testing and integration testing support

#### Benefits of Server-Side Implementation
1. **Robust Architecture**: Proper MVC separation of concerns
2. **Scalability**: Can handle complex business requirements
3. **Security**: Business logic protected from client manipulation
4. **Testability**: Full unit testing capabilities
5. **Extensibility**: Easy to add features like data persistence, logging, etc.
6. **Maintainability**: Clear code organization and structure

## Learning Outcomes

This branch demonstrates:
- **ASP.NET Core 8.0 MVC architecture** with proper separation of concerns
- **Model binding** and strongly-typed views
- **Server-side form processing** and validation
- **Evolution** from client-side to server-side architecture
- **Trade-offs** between different architectural approaches
- **Enterprise-ready** web application patterns

## Next Steps

- **Compare with 1.0-ui branch** to understand client vs server trade-offs
- **Explore main branch** to see the foundation both branches build upon
- **Consider hybrid approaches** that combine real-time UI with server validation
- **Add features** like data persistence, logging, or API endpoints
- **Implement unit tests** to demonstrate testability advantages
