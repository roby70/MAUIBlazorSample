# MyBlazorDemo

Applicazione demo per verificare il funzionamento di applicazioni
MAUI ibride (Blazor) su Android e iOS e la condivisione dei componenti
con le applicazioni web Blazor.

## Progetto

Il progetto è stato creato con il template `.NET MAUI Blazor Hybrid and Web App` 
di Visual Studio 2022.

Di seguito i progetti contenuti nella soluzione:

- `MyBlazorDemo.MAUI`: il progetto principale per l'applicazione MAUI
- `MyBlazorDemo.MAUI.Shared`: la libreria condivisa tra l'applicazione MAUI e l'applicazione Blazor.
  Contiene i componenti dell'intefaccia utente e le classi di servizio
  condivise tra i due tipi di applicazione.
- `MyBlazorDemo.MAUI.Web`: il progetto server che ospita l'applicazione Blazor WASM.
- `MyBlazorDemo.MAUI.Web.Client`: l'applicazione Blazor WASM (client side).