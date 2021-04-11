using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{ Id=1, Name= "White"},
                new Color{ Id=1, Name= "Black"},
                new Color{ Id=1, Name= "Gray"},
                new Color{ Id=1, Name= "Blue"},
                new Color{ Id=1, Name= "Red"},
            };
        }

    }
}
