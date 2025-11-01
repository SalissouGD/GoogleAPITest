# Gemini ChatBot - Application MAUI

Application de chatbot multiplateforme développée avec .NET MAUI et propulsée par Google Gemini AI.

## Fonctionnalités

- Interface de chat moderne et intuitive, similaire à ChatGPT
- Communication en temps réel avec le modèle Gemini 2.5 Flash
- Support du mode clair et sombre
- Interface responsive adaptée à toutes les plateformes
- Architecture MVVM pour une maintenance facilitée

## Prérequis

- .NET 9.0 SDK
- Visual Studio 2022 avec la charge de travail .NET MAUI
- Clé API Gemini (disponible sur [Google AI Studio](https://makersuite.google.com/app/apikey))

## Configuration

### 1. Configurer la clé API

Avant de lancer l'application, vous devez configurer votre clé API Gemini comme variable d'environnement :

**Windows (PowerShell) :**
```powershell
$env:GEMINI_API_KEY = "votre_clé_api_ici"
```

**Windows (Invite de commandes) :**
```cmd
set GEMINI_API_KEY=votre_clé_api_ici
```

**Linux/macOS :**
```bash
export GEMINI_API_KEY="votre_clé_api_ici"
```

### 2. Installer les dépendances

```bash
cd GeminiChatBot
dotnet restore
```

### 3. Compiler l'application

Pour Windows :
```bash
dotnet build -f net9.0-windows10.0.19041.0
```

Pour Android :
```bash
dotnet build -f net9.0-android
```

Pour iOS :
```bash
dotnet build -f net9.0-ios
```

### 4. Lancer l'application

Pour Windows :
```bash
dotnet run -f net9.0-windows10.0.19041.0
```

Ou directement depuis Visual Studio en sélectionnant le framework cible souhaité.

## Structure du projet

```
GeminiChatBot/
├── Models/
│   └── ChatMessage.cs          # Modèle de message de chat
├── ViewModels/
│   └── ChatViewModel.cs        # ViewModel principal avec logique métier
├── Services/
│   └── GeminiService.cs        # Service de communication avec Gemini API
├── Converters/
│   ├── BoolToColorConverter.cs
│   ├── BoolToTextColorConverter.cs
│   ├── BoolToMarginConverter.cs
│   └── InverseBoolConverter.cs
├── MainPage.xaml               # Interface utilisateur principale
└── MauiProgram.cs              # Configuration DI et services
```

## Utilisation

1. Lancez l'application
2. Tapez votre message dans le champ de saisie en bas de l'écran
3. Appuyez sur Entrée ou cliquez sur le bouton d'envoi
4. L'IA répondra à votre message
5. Utilisez le bouton "Effacer" pour recommencer une nouvelle conversation

## Technologies utilisées

- .NET MAUI 9.0
- CommunityToolkit.Mvvm 8.4.0
- Google_GenerativeAI 3.4.0
- Architecture MVVM
- Dependency Injection

## Notes importantes

- Assurez-vous que la variable d'environnement `GEMINI_API_KEY` est bien définie avant de lancer l'application
- L'application nécessite une connexion Internet pour communiquer avec l'API Gemini
- Les messages sont stockés en mémoire et seront perdus lors de la fermeture de l'application

## Troubleshooting

### Erreur "GEMINI_API_KEY environment variable is not set"
Vérifiez que vous avez bien configuré la variable d'environnement avant de lancer l'application.

### Erreur de connexion à l'API
Vérifiez votre connexion Internet et que votre clé API est valide.

## Licence

Ce projet est un exemple de démonstration.
