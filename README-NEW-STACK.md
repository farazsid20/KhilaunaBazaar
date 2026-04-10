# KhilaunaBazaar - .NET Web API + Blazor WebAssembly

This solution contains:

- **Backend**: ASP.NET Core Web API (`src/KhilaunaBazaar.Api`) – products, categories, contact API.
- **Frontend**: Blazor WebAssembly standalone app (`src/KhilaunaBazaar.Client`) – SPA that calls the API.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download) (or .NET 10 if the Client was created with it)

## Run the application

### 1. Start the API

```bash
cd src/KhilaunaBazaar.Api
dotnet run
```

The API runs at **http://localhost:5000** (and https://localhost:5001 if using the `https` launch profile).

### 2. Start the Blazor client

In a second terminal:

```bash
cd src/KhilaunaBazaar.Client
dotnet run
```

The Blazor app runs at the URL shown in the terminal (e.g. **http://localhost:5163**). Open it in a browser.

### 3. API base URL

The client is configured to use `http://localhost:5000` by default. To change it, edit:

- `src/KhilaunaBazaar.Client/wwwroot/appsettings.json`  
- `src/KhilaunaBazaar.Client/wwwroot/appsettings.Development.json`

Set `ApiBaseUrl` to your API base URL (e.g. `https://localhost:5001` if the API runs with HTTPS).

## API endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/products` | All products |
| GET | `/api/products/featured?count=4` | Featured products |
| GET | `/api/products/category/{slug}` | Products by category |
| GET | `/api/products/{id}` | Product by ID |
| GET | `/api/categories` | All categories |
| GET | `/api/categories/{slug}` | Category by slug |
| POST | `/api/contact` | Submit contact form (JSON body) |

## Project structure

```
KhilaunaBazaar/
├── KhilaunaBazaar.sln
├── src/
│   ├── KhilaunaBazaar.Api/          # Web API
│   │   ├── Controllers/
│   │   ├── Models/
│   │   ├── Services/
│   │   └── Program.cs
│   └── KhilaunaBazaar.Client/       # Blazor WASM
│       ├── Layout/
│       ├── Models/
│       ├── Pages/
│       ├── Services/
│       └── wwwroot/
```

The original static HTML/JS site is still in the repo root (e.g. `index.html`, `css/`, `js/`, `categories/`). The new stack lives under `src/`.
