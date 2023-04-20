using EstrellaWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EstrellaWebApi.Entities;

namespace EstrellaWebApi.Models
{
    public class ResponseService
    {
        public ResponseService(Услуги service)
        {
            Id= service.Id;
            Type = service.Вид_услуги1.Название;
            Name = service.Название;
            Time = service.Время;
            Money = service.Стоимость;
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Money { get; set; }
    }
}