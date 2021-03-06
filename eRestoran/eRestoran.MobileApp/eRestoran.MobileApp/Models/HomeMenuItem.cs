﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.MobileApp.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Profil, 
        Obavijesti,
        Jela, 
        Email,
        Rezervacija,
        VaseRezervacije,
        VaseNarudzbe
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
