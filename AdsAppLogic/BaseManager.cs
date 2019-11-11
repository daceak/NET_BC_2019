using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsAppLogic
{
    public abstract class BaseManager<T>
            where T : BaseData //so japieliek, ja nu norada datubazei nederigu mainigo- ne klasi. un : BaseData norada ka jaatbilst basedata klasei (jeb bus Id vienmer, jo saja klase tas ir noradits)

    {
        protected AdsAppDB _db; //protected starp prvatu un publisku. pieejams sai un klases kas manto so klasi
        //_ svitru rada privatajam mainigajam , ko var izmantot visas metodes utt
        protected abstract DbSet<T> Table { get; } //dbset tika nodefinets webshopdb klase, dazadas tabulas ka dbset


        public BaseManager(AdsAppDB db)
        {
            _db = db; //ieliek sanemto datubazi mainigaja _db kas atbilst strukturai klase WebShopDB
        }

        public T Get(int id) //T mainigs tips. izsaucot metodi sis tips tiks aizvietots
        {
            return Table.FirstOrDefault(i => i.Id == id);
        }

        public List<T> GetAll()
        {

            return Table.ToList();
        }

        public T Create(T data)
        {
            Table.Add(data);
            _db.SaveChanges();
            return data; //return mes nelietojam, bet ja vajadzetu talak izmantot kko no izveidota objekta, tad atgrieztu. labak uzreiz taisit ar atgriesanu
        }

        public void Update(T data)
        {
            Table.Update(data); //update metode iebuveta metode entity framework. atradis pec primaras atslegas (parasti ir id)
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = Table.FirstOrDefault(i => i.Id == id);
            Table.Remove(item);
            _db.SaveChanges();
        }

        //CRUD create read update delete
    }
}
