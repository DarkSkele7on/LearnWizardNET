using System;
using System.Threading.Tasks;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;

namespace ServiceLayer
{
    public class OpenApi
    {
        private readonly string _apiKey;
        private readonly OpenAIAPI _openAiApi;


        public OpenApi(string apiKey)
        {
            _apiKey = apiKey;
            _openAiApi = new OpenAIAPI(new APIAuthentication(_apiKey));
        }

        public async Task<string> GenerateCourseDescriptionAsync(string prompt)
        {
            try
            {
                string model = "gpt-3.5-turbo-instruct";
                int maxTokens = 150;

                // Create a new completion request
                CompletionRequest request = new CompletionRequest()
                {
                    Model = model,
                    Prompt = prompt,
                    MaxTokens = maxTokens,
                    Temperature = 0.3,
                    
                };

                CompletionResult completionResult = await _openAiApi.Completions.CreateCompletionAsync(request);


            if (completionResult != null)
            {
                var generatedText = completionResult.Completions[0].Text;
                
                //Console.WriteLine(generatedText);
                return generatedText;
            }
            else
            {
                Console.WriteLine("Error: Completion result is null or empty.");
                return null;
            }
            }
            catch (Exception ex)
            {
                // Handle any errors and return null
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

    }
}
