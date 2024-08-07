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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFile;

        public ImageFileManager(IImageFileDal imageFile)
        {
            _imageFile = imageFile;
        }

        public List<ImageFile> GetList()
        {
           return  _imageFile.List();
        }
    }
}
