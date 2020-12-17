using System;
using System.Collections.Generic;

namespace CoreApp.Entities
{
    public partial class Photo
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string TableName { get; set; }
        public int? UserId { get; set; }
        public string DirectoryPath { get; set; }
    }
}
