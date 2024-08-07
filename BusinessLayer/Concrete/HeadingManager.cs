﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
       

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
           
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetByWriterList(int id)
        {
            return _headingDal.List(x => x.WriterId == id);
        }

        public List<Heading> GetList()
        {
           return _headingDal.List();
        }
        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        //Silme(Pasif-Aktif Alma)
        public void HeadingDelete(Heading heading)
        {
          
            _headingDal.Update(heading);//ve güncelle
          
        }

        public void HeadingUpdate(Heading heading)
        {
           _headingDal.Update(heading);
        }

     
    }
}
