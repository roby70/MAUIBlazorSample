# MyBlazorDemo

Applicazione demo per verificare il funzionamento di applicazioni
MAUI ibride (Blazor) su Android e iOS e la condivisione dei componenti
con le applicazioni web Blazor.

## Progetto

Il progetto è stato creato con il template `.NET MAUI Blazor Hybrid and Web App` 
di Visual Studio 2022.

Di seguito i progetti contenuti nella soluzione:

- `MAUI.App`: il progetto principale per l'applicazione MAUI
- `Blazor.Shared`: la libreria condivisa tra l'applicazione MAUI e l'applicazione Blazor.
  Contiene i componenti dell'intefaccia utente e le classi di servizio
  condivise tra i due tipi di applicazione.
- `Blazor.Web.Server`: il progetto server che ospita l'applicazione Blazor WASM.
- `Blazor.Web.Client`: l'applicazione Blazor WASM (client side).
- `APIServices`: classi comuni utilizzate per accedere alle 
  API del servizio di back-end, sia da parte della applicazione MAUI che 
  da parte dell'applicazione Blazor (WASM).

## API

L’applicazione espone gli endpoint di back-end all’interno del progetto **Blazor.Web.Server**, 
che funge da host sia per l’applicazione Blazor WebAssembly sia per le API.  
Questi endpoint sono gestiti principalmente come **Minimal APIs** e sono 
suddivisi in base alle funzionalità (ad esempio un gruppo “Weather”, un gruppo “Auth”, ecc.).  

Nei file di “endpoint” (o cartelle come `Endpoints/Weather`) è presente la definizione 
dei metodi `MapGet()`, `MapPost()` e così via, che mettono a disposizione 
i dati/servizi necessari.  
Nel file principale `Program.cs` di **Blazor.Web.Server** vengono poi **registrati** 
i servizi (ad es. `IWeatherService`) e “agganciati” gli endpoint (tramite `MapGroup("/api/weather")` 
o simili).

### Suddivisione tra i vari progetti

- **Blazor.Shared**: Contiene i **model** (ad esempio `WeatherForecast`) e le **interfacce** 
  (`IWeatherService`) condivise. In questo modo, sia il server che i client 
  (MAUI e Blazor WASM) utilizzano lo stesso contratto di servizio.  

- **Blazor.Web.Server**: Implementa fisicamente gli **endpoint API** (Minimal APIs) e 
  le classi di servizio (ad es. `WeatherService`) che forniscono i dati reali 
  o fittizi, registrati poi nel contenitore DI (`builder.Services.AddScoped<IWeatherService, WeatherService>();`).  

- **APIServices**: Contiene le **classi client** (ad esempio `WeatherServiceHttp`) 
  che sanno come chiamare gli endpoint di **Blazor.Web.Server** via HTTP. 
  Entrambi i progetti client (MAUI e Blazor WASM) fanno riferimento a questa libreria 
  per riutilizzare la stessa logica di chiamata.  

### Configurazione dei client

- **MAUI.App**: Nel file `MauiProgram.cs` si crea un’istanza di `HttpClient` puntando 
  all’URL del server (es. `https://192.168.x.x:5001`) e si registra 
  `WeatherServiceHttp` (o altri servizi) come implementazione di `IWeatherService`.  
  In questo modo, la app MAUI può consumare le API via HTTP anche da dispositivi mobili 
  o da Windows.

- **Blazor.Web.Client (WASM)**: Nel file `Program.cs`, si registra un `HttpClient` 
  con `builder.Services.AddScoped(...)`, usando come `BaseAddress` quella dell’applicazione 
  corrente (o di un server esterno). Anche qui si aggiunge l’implementazione di `IWeatherService` 
  puntando agli stessi endpoint `/api/...`.  

Grazie a questa struttura, la parte server e i due client condividono i **model** e le **interfacce**, 
mentre **APIServices** fornisce un’implementazione comune per la logica di chiamata HTTP, 
garantendo che MAUI e Blazor WASM consumino le stesse API con codice riutilizzabile.