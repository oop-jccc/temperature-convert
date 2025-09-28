# Temperature Convert - Main Branch

## Branch Purpose

This is the **baseline branch** containing a standard ASP.NET Core MVC web application template. It serves as the foundation for the temperature conversion project, demonstrating the initial project structure before any custom functionality is implemented.

## Key Features

- **Standard ASP.NET Core MVC Template**: Clean, unmodified project structure
- **Bootstrap Integration**: Pre-configured responsive UI framework
- **Basic Navigation**: Home and Privacy pages with standard layout
- **Development Foundation**: Ready-to-extend architecture for custom functionality
- **Modern Framework**: Built on ASP.NET Core 8.0 for optimal performance

### Technology Stack
- **Framework**: ASP.NET Core 8.0
- **Pattern**: Model-View-Controller (MVC)
- **Frontend**: Razor Views with Bootstrap 5.1
- **Backend**: C# with minimal controller logic

### Project Structure
```
TemperatureConvert/
├── Controllers/
│   └── HomeController.cs          # Basic MVC controller
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml           # Welcome page
│   │   └── Privacy.cshtml         # Privacy policy page
│   └── Shared/
│       ├── _Layout.cshtml         # Main layout template
│       └── _ViewStart.cshtml      # View configuration
├── wwwroot/                       # Static files (CSS, JS, images)
├── appsettings.json              # Application configuration
└── Program.cs                    # Application entry point
```

## How to Run

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- Any IDE that supports .NET (Visual Studio, VS Code, Rider)

### Running the Application

1. **Clone the repository**:
   ```bash
   git clone https://github.com/d-german/temperature-convert.git
   cd temperature-convert
   ```

2. **Ensure you're on the main branch**:
   ```bash
   git checkout main
   ```

3. **Navigate to project directory**:
   ```bash
   cd TemperatureConvert
   ```

4. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

5. **Run the application**:
   ```bash
   dotnet run
   ```

6. **Access the application**:
   - Open browser to `https://localhost:7065` or `http://localhost:5076`
   - You'll see the standard ASP.NET Core welcome page

## Code Highlights

### Basic HomeController.cs
```csharp
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
```

### Standard Index.cshtml
```html
@{
    ViewData["Title"] = "Home Page";
}

<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>Learn about <a href="https://docs.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
</div>
```

### Key Implementation Details
- **MVC Pattern**: Clear separation of Models, Views, and Controllers
- **Dependency Injection**: Built-in DI container with logger injection
- **Error Handling**: Standard error page with request tracking
- **Responsive Design**: Bootstrap framework for mobile-friendly UI
- **Configuration**: JSON-based application settings

## Architecture Overview

### MVC Architecture
```
ASP.NET Core MVC
├── Models (Data & Business Logic)
├── Views (User Interface)
└── Controllers (Request Handling)
```

### Request Flow
1. User requests a URL
2. Routing engine maps URL to controller action
3. Controller processes the request
4. Controller returns a view with optional model data
5. View engine renders HTML response
6. Response sent back to user's browser

## Comparison with Other Branches

### What Other Branches Add

#### **1.0-ui Branch**
- **Client-Side Temperature Conversion**: JavaScript-based real-time conversion
- **Interactive UI**: Input fields with instant feedback
- **No Server Processing**: All calculations done in browser
- **Real-Time Experience**: Immediate results without form submission

#### **2.0-server Branch**
- **Server-Side Processing**: Full MVC implementation with models
- **Form-Based Workflow**: Traditional web form submission
- **Data Models**: Proper separation with dedicated model classes
- **Server-Side Validation**: Robust validation capabilities
- **Enterprise Architecture**: Scalable, testable, maintainable structure

### Why Start with Main Branch
- **Clean Foundation**: Understand basic ASP.NET Core structure
- **Learning Path**: See how applications evolve from templates
- **Best Practices**: Standard project organization and conventions
- **Extensibility**: Ready platform for adding custom functionality

## Learning Outcomes

This branch demonstrates:
- **ASP.NET Core 8.0 fundamentals** and project structure
- **MVC pattern basics** with controllers and views
- **Standard web application** setup and configuration
- **Foundation concepts** before adding custom functionality
- **Modern .NET development** practices and conventions

## Next Steps

### Explore Other Branches
1. **1.0-ui Branch**: See client-side JavaScript implementation
   ```bash
   git checkout 1.0-ui
   ```

2. **2.0-server Branch**: Explore server-side MVC architecture
   ```bash
   git checkout 2.0-server
   ```

### Development Path
- **Start Here**: Understand the foundation
- **Move to 1.0-ui**: Learn client-side development
- **Progress to 2.0-server**: Master server-side architecture
- **Compare Approaches**: Understand trade-offs between implementations

### Extension Ideas
- Add database integration
- Implement user authentication
- Create REST API endpoints
- Add unit testing
- Implement logging and monitoring

## Benefits of This Foundation

1. **Standard Structure**: Industry-standard ASP.NET Core organization
2. **Scalable Architecture**: Ready for enterprise-level features
3. **Modern Framework**: Latest .NET 8.0 capabilities
4. **Development Ready**: Configured for immediate development
5. **Learning Platform**: Perfect starting point for understanding web development

This main branch serves as the essential foundation that both specialized branches build upon, demonstrating how a simple template can evolve into sophisticated applications with different architectural approaches.
