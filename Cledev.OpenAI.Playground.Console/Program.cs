﻿using System.Text.Json;
using Cledev.OpenAI.Extensions;
using Cledev.OpenAI.V1;
using Cledev.OpenAI.V1.Contracts.Moderations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var jsonSerializerOptions = new JsonSerializerOptions
{
    WriteIndented = true
};

Console.WriteLine("OpenAI.NET Example");

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>();

IConfiguration configuration = builder.Build();
var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped(_ => configuration);

serviceCollection.AddOpenAIClient();

var serviceProvider = serviceCollection.BuildServiceProvider();
var client = serviceProvider.GetRequiredService<IOpenAIClient>();

//Models
//var response = await client.ListModels();
//var response = await client.RetrieveModel("text-davinci-003");

//Completions
//var response = await client.CreateCompletion(CompletionsModel.Ada, "Say something nice");
//var response = await client.CreateCompletion("What is MOB programming?", OpenAIModels.TextDavinciV3, maxTokens: 100);

//Edits
//var response = await client.CreateEdit(input: "What day of the wek is it?", instruction: "Fix the spelling mistakes");

//Images
//var response = await client.CreateImage(prompt: "A cute baby sea otter");

//Embeddings
//var response = await client.CreateEmbeddings(new CreateEmbeddingsRequest
//{
//    Model = EmbeddingsModel.TextEmbeddingAdaV2.ToStringModel(),
//    Input = "The food was delicious and the waiter..."
//});

//Files
//var file = await File.ReadAllBytesAsync("Data/fine-tune-1.jsonl");
//var uploadedFile = await client.UploadFile(file, "fine-tune-1.jsonl", "fine-tune");
//var response = await client.RetrieveFile(uploadedFile!.Id);

//Fine Tunes
//var response = await client.ListFineTunes();

//Moderations
var response = await client.CreateModeration(new CreateModerationRequest
{
    Input = "I want to kill them"
});

Console.WriteLine($"{JsonSerializer.Serialize(response, jsonSerializerOptions)}");

Console.ReadKey();
