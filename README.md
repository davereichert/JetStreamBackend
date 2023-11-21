
# JetStreamBackend

## Überblick
JetStreamBackend ist ein Backend-Service für die Verwaltung von Ski-Services und Mitarbeiterdaten. Es bietet eine API für Authentifizierung, Verwaltung von Serviceaufträgen und Mitarbeiterinformationen.

## Technologien
- .NET Core
- Entity Framework Core
- SQL Server

## Installation

### Voraussetzungen
- .NET Core SDK
- SQL Server
- diese müssen installiert sein 
https://dotnet.microsoft.com/en-us/download/dotnet/8.0

### Schritte
1. **Repository klonen**
   ```bash
   git clone https://github.com/davereichert/JetStreamBackend.git
   cd JetStreamBackend
   ```
   - oder über die Webseite klonen

2. **Datenbank einrichten**
   - Stellen Sie sicher, dass SQL Server läuft.
   - Führen Sie die Migrationsdateien aus, um die Datenbank zu initialisieren

     ```bash
     dotnet tool install --global dotnet-ef

     dotnet ef database update  --connection "Server=localhost;Database=JetStream;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
     ```

3. **Anwendung starten**
   ```bash
   dotnet restore
   dotnet run
   ```

## Verwendung
Die Anwendung bietet folgende Endpunkte:
- Authentifizierung (`/auth`)
- Serviceaufträge (`/serviceauftrag`)
- Mitarbeiterverwaltung (`/mitarbeiter`)

## Lizenz
[MIT](https://choosealicense.com/licenses/mit/)

---

