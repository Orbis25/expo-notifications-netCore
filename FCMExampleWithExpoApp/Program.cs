using Expo.Server.Client;
using Expo.Server.Models;
using System;
using System.Collections.Generic;

namespace FCMExampleWithExpoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //instanciamos la clase que contiene los metodos para enviar la notificación
            var expoSDKClient = new PushApiClient();
            //instanciamos el modelo que contendra la información
            var pushTicketReq = new PushTicketRequest()
            {
                PushTo = new List<string> { "{YOU_EXPO_TOKEN}"},
                PushBadgeCount = 7,
                PushBody = "HI I AM A GREAT DEVELOPER!",
            };

            /*
             -creamos una variable con el resultado para luego verificar si ocurrió algún error
             -llamamos al metodo PushSendAsync le pasamos el modelo PushTicketRequest el cual devuelve
             un taskAwaiter por eso el metodo .GetAwaited() y luego llamamos getResult()
             (ESTO ES UN METODO ASYNCRONO)
             
             */
            var result = expoSDKClient.PushSendAsync(pushTicketReq).GetAwaiter().GetResult();
            //verificamos si hay errores
            if (result?.PushTicketErrors?.Count > 0)
            {
                foreach (var error in result.PushTicketErrors)
                {
                    Console.WriteLine($"Error: {error.ErrorCode} - {error.ErrorMessage}");
                }
            }


            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
