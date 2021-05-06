# RistoGest
Progetto Blazor per l'esame finale del corso ICT.

---------- Progettazione della soluzione ---------- <br />
Viene richiesto di realizzare un sistema per la gestione del sistema centralizzato di consegne a domicilio per un ristorante. In particolare, si dovrà consentire all’utente di poter gestire i piatti proposti alla clientela in un database con le classiche operazioni CRUD: create, read, delete e update. La tipologia di software è quella di SPA (Single Page Application) realizzata per mezzo del web framework Blazor. La soluzione sarà quindi accessibile da qualsiasi dispositivo in cui sia installato un browser (Pc, smartphone, tablet, …). 

---------- Esecuzione della soluzione ---------- <br />
Creiamo un progetto Blazor di nome RistoGest all’interno di una cartella nominata anch’essa RistoGest, al cui interno saranno inseriti tutte le componenti del progetto. Tra le componenti c’è il database, che sarà di tipo SQLite, quindi un singolo file con estensione db.
Per poter connettere il progetto Blazor ad una database, occorrerà installare i pacchetti Nuget Microsoft.EntityFrameworkCore (una libreria che consente l’accesso ad un database nell’ambiente di sviluppo .NET) e Microsoft.EntityFrameworkCore.Sqlite (una libreria specifica per i database SQLite). <br />
Il database che utilizzeremo, nominato RistoDB, sarà composto da una tabella denominata Piatti, al cui interno inserisco le colonne: id (di tipo integer e proprietà autoincrement, che sarà la chiave primaria della tabella), tipo di portata, nome del piatto, allergeni, stagione di presentazione (tutte di tipo string) e prezzo, che sarà di tipo decimal con precisione 5 e scala 2. Nel campo prezzo sarà quindi possibile inserire un valore massimo di 999,99.
Ogni colonna corrisponde ad un attributo della classe Piatto che creiamo nella cartella Data della soluzione Blazor. Gli attributi della classe Piatto saranno di tipo esattamente uguale a quello delle colonne del database. <br />

Viene impostato un campo Id, con chiave primaria ed incremento automatico, che non sarà visibile all’utente che servirà al software per catalogare i record. 
Creiamo una classe per il database che chiamiamo DataBase.cs la quale implementerà il DbContext tramite la direttiva using Microsoft.EntityFrameworkCore da scrivere prima del namespace. La classe DataBase.cs sarà definita dall’attributo pubblico “Piatti”, che corrisponde al nome della tabella del database RistoDB, tipizzato come un set di elementi della classe Piatto con la dicitura DbSet<Piatto>.
Aggiungiamo alla classe Database.cs l’opzione public DataBase(DbContextOptions options) : base(options) { }. Inseriamo nel file _Imports.razor nella cartella Shared la direttiva @using BlazorUltime.Data per poter importare i contenuti della cartella Data. <br />
 
A questo punto creiamo la componente Piatti.razor dove andremo ad inserire sia il codice Html e Css (tramite Bootstrap) per la parte di Front-end sia il codice C# per la parte di Back-end. La parte centrale della pagina sarà occupata dalla tabella dei record che permette quindi l’operazione Read della quadrupla CRUD. L’operazione di Create è affidata ad un tasto “Nuovo piatto” che permette di aprire un form di inserimento. <br />
 Le operazioni di Update e Delete sono accessibili attraverso due pulsanti presenti a lato di ogni record della tabella. Prima dell’esecuzione dell’operazione di cancellazione del record, richiamiamo il servizio IJSRunTime mettendo in alto alla pagina @inject IJSRuntime JsRuntime. In questo modo sarà offerta all’utente la possibilità di confermare o meno l’operazione di cancellazione ed evitare così eventuali click non desiderati. <br />
 
Tutti gli elementi input ed i bottoni contengono l’attributo <title> che descrive la funzionalità dell’elemento, per permetterne la comprensione agli utenti ipovedenti. 
Viene inserito anche un tasto Annulla che permetta all’utente di annullare un’operazione di inserimento o modifica qualora questa fosse stata avviata per errore.
Aggiungiamo nel file NavMenu.razor nella cartella Shared il collegamento alla pagina Piatti.razor, in modo da poterla rendere accessibile dal menu principale. Apriamo la componente Startup.cs ed inseriamo la direttiva using Microsoft.EntityFrameworkCore; necessaria per inserire la connessione al database. 
Inseriamo il metodo AddDbContext nella sezione ConfigureServices della componente Startup.cs per realizzare la connessione tra il progetto Blazor e il file di database SQLite presente nella stessa cartella. <br />
Come ultimo passaggio per la connessione al Db, inseriamo nel file appsettings.json la stringa di connessione che sarà poi la stessa utilizzata nel passaggio precedente "DataSource=RistoDB.db".   

---------- Caricamento su GitHub ----------<br />
Aggiungiamo un file .gitignore per non caricare file da ignorare ed un file .gitattributes che assegna gli attributi ai percorsi dei file. Infine, eseguiamo il push della cartella sul repository di GitHub. 
 
