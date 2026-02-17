# insights-backend

Service 2: Handling the Firebase Cloud Message and Database

```txt
insights-backend/
├── Models/
│   ├── PushNotificationRequest.cs
│   ├── AndroidOverrides.cs
│   └── ApnsOverrides.cs
├── Builders/
│   ├── INotificationPayloadBuilder.cs
│   ├── ChatMessageNotification.cs
│   └── OrderStatusNotification.cs
├── Services/
│   └── PushNotificationService.cs    ← maps your models → Firebase SDK
└── Controllers/
    └── NotificationsController.cs
```

## Setting up

You have to add 3 files `launchSettings.json` and `appsetting.json`

`launchSettings.json` in Folder `insights-backend/Properties`

```json
{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "http://localhost:5197",
      "environmentVariables": {
        "GOOGLE_APPLICATION_CREDENTIALS": "your-firebase-credential",
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "https://localhost:7038;http://localhost:5197",
      "environmentVariables": {
        "GOOGLE_APPLICATION_CREDENTIALS": "your-firebase-credential",
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

`appsetting.json` in `insights-backend`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },

  "ConnectionStrings": {
    "PostgreSQL": "postgres_connetion_string"
  },

  "MongoDB": {
    "ConnectionString": "mongodb_connection_string",
    "DatabaseName": "database_name",
    "Collection": "collection_name",
  },
  "AllowedHosts": "*"
}
```

`appsetting.Developement.json`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```