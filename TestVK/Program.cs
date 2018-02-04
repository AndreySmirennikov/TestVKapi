using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.IO;

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
            String request="https://api.vk.com/method/"+args[1]+"?";
                                                                    
            
            for (int i = 2; i <args.Length; i++)
            {
                if(i==2)request=request+args[i];
                else request=request+"&"+args[i];
            }
            
            
            ProcessRepositories(request,args[0]).Wait();
            
            
        }

        
        private static async Task ProcessRepositories(string request,string name)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            var stringTask = client.GetStringAsync(request);
            var msg = await stringTask;
            Console.Write(msg);

            FileStream file1;
            String fullPath = Path.GetFullPath("reports");
            if(File.Exists(fullPath+"\\"+name+".txt"))file1 = new FileStream(fullPath+"\\"+name+".txt", FileMode.Append);
            else file1 = new FileStream(fullPath+"\\"+name+".txt", FileMode.OpenOrCreate); 
            StreamWriter writer = new StreamWriter(file1);  
            writer.WriteLine("=========================={0}====================================\n",DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss"));
            writer.WriteLine("Request:{0}",request);
            writer.WriteLine("Response:{0}\n",msg);
            writer.WriteLine("==============================================================\n");    
            writer.Close(); 


        }
    }
}
