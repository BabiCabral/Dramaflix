using System;
using System.Collections.Generic;
using DIO.Doramaflix.Interfaces;

namespace DIO.Doramaflix
{
    public class DramaRepository : IRepository<Drama>
    {
        private List<Drama> listDrama = new List<Drama>();
        public void Update(int id, Drama objeto)
        {
            listDrama[id] = objeto;
        }
        public void Delete(int id)
        {
            listDrama[id].Delete();
        }
        public void Insert(Drama objeto)
        {
            listDrama.Add(objeto);
        }
        public List<Drama> List()
        {
            return listDrama;
        }
        public int NextId()
        {
            return listDrama.Count;
        }
        public Drama ReturnsById(int id)
        {
            return listDrama[id];
        }
    }

}