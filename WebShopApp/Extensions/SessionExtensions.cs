using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApp
    //can take . part from name to make it available everywhere
    //session var stradat tikai ar strings un int
{
    public static class SessionExtensions //static jo paligfunkcija. si metode ir arpus klases
    {
        private const string MAIL = "useremail";
        private const string ID = "userid"; //id string jo tas ir sesijas mainigais nosaukums zem kura liek int vertibas
        private const string BASKET = "userbasket";
        
        public static void SetUserEmail(this ISession session, string email) //this isession aktiva sesija
        {
            session.SetString(MAIL, email);    //useremail ir ka kolonnas nosakums zem kura liek vertibas lai tas neparrakstitos      
        }

        public static string GetUserEmail(this ISession session)
        {
            return session.GetString(MAIL); //zem usermail ieprieks tika no sesijas saglabata vertiba, ko tagad dabut atpakal
        }
        public static void SetUserId(this ISession session, int id)
        {
            session.SetInt32(ID, id);
        }

        public static int? GetUserId(this ISession session) //int ar ? zimi jo int nevar but tukss jeb null, ar ? norada, ka var but null vertiba
        {
            return session.GetInt32(ID);
        }

        public static void SetUserBasket(this ISession session, List<int> items)
        {
            var json = JsonConvert.SerializeObject(items); //katram objektam ir sava atslega un vertiba (piem., sarakstiem utt)

            session.SetString(BASKET, json);
        }

        public static List<int> GetUserBasket(this ISession session)
        {
            var json = session.GetString(BASKET);
            return json == null? null : JsonConvert.DeserializeObject<List<int>>(json);
        }
    }
}
