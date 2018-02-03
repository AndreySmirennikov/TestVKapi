using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace WebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        
        public static void Main(string[] args)
        {
            //я выбрал передачу параметров запроса через aргументы командной строки
            //Потому, что мне кажется это самый удобный вариант
            //Однако  код ниже легко преобразовать под любой другой  ввод парамтров  для вызова API
            String request="https://api.vk.com/method/"+args[0]+"?";
                                                                    
            
            for (int i = 1; i <args.Length; i++)
            {
                if(i==1)request=request+args[i];
                else request=request+"&"+args[i];
            }
            
            
            ProcessRepositories(request).Wait();
        }

        
        private static async Task ProcessRepositories(string request)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            var stringTask = client.GetStringAsync(request);
            var msg = await stringTask;
            Console.Write(msg);
        }
    }
}
