# Cledev.OpenAI _(Beta)_
.NET 7 SDK for OpenAI with a Blazor Server playground _(work in progress)_

[![Main](https://github.com/lucabriguglia/Cledev.OpenAI/actions/workflows/main.yml/badge.svg)](https://github.com/lucabriguglia/Cledev.OpenAI/actions/workflows/main.yml)
[![Nuget Package](https://img.shields.io/badge/nuget-1.0.0-blue.svg)](https://www.nuget.org/packages/Cledev.OpenAI)

```
Install-Package Cledev.OpenAI
```

## APIs

- **Models**
  - List Models
  - Retrieve Model
- **Completions**
  - Create Completion
- **Edits**
  - Create Edit
- **Images**
  - Create Image
  - Create Image Edit
  - Create Image Variation
- **Embeddings**
  - Create Embeddings
- **Files**
  - List Files
  - Upload File
  - Delete File
  - Retrieve File
- **Fine-tunes**
  - Create Fine-tune
  - List Fine-tunes
  - Retrieve Fine-tune
  - Cencel Fine-tune
  - List Fine-tune Events
  - Delete Fine-tune Model
- **Moderations**
  - Create Moderation

## Blazor Playground

<img src="https://user-images.githubusercontent.com/8679253/219879876-209b600d-44d9-4491-bfa4-7e1caeae7c5a.png" width="600" />
<img src="https://user-images.githubusercontent.com/8679253/219879883-92370a6f-3826-43a1-8ed9-fc5f02c0d1f8.png" width="600" />
<img src="https://user-images.githubusercontent.com/8679253/219881434-b383acf5-2eb5-4de9-b3ad-2f5a916f09c8.png" width="600" />

## Configuration

### Option 1

```C#
services.AddOpenAIClient();
```

This option requires an appsettings.json file

```json
{
  "OpenAI": {
    "ApiKey": "YOUR_API_KEY",
    "Organization": "OUR_ORGANIZATION"
  }
}
```

### Option 2

```C#
services.AddOpenAIClient(options =>
{
     options.ApiKey = "YOUR_API_KEY";
     options.Organization = "YOUR_ORGANIZATION";
 });
```

## Usage

Inject `IOpenAIClient` interface into your service

_(complete guide available soon)_
