using Microsoft.EntityFrameworkCore;
using ProgramowanieProj3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieProj3.ViewModel
{
    public partial class BaseModel : INotifyPropertyChanged
    {
        public ProgProj3Context context = new ProgProj3Context();

        public event PropertyChangedEventHandler PropertyChanged;

        public void onPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
