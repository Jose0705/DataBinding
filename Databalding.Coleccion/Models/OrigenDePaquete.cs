
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databalding.Coleccion.NewFolder
{
    public class OrigenDePaquete : INotifyPropertyChanged
    {
        private string? _nombre = string.Empty;
        private string? _origen = string.Empty;
        private bool _estaHabilitado = false;

        public string? Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        public string? Origen
        {
            get => _origen;
            set
            {
                if (_origen != value)
                {
                    _origen = value;
                    OnPropertyChanged(nameof(Origen));
                }
            }
        }

        public bool Estahabilitado
        {
            get => _estaHabilitado;
            set
            {
                if (_estaHabilitado != value)
                {
                    _estaHabilitado = value;
                    OnPropertyChanged(nameof(Estahabilitado));
                }
            }
        }

        //Notificamos que una propiedad cambio
        public event PropertyChangedEventHandler? PropertyChanged;
        public override string ToString()
        {
            return $"{Nombre} - {Origen}";
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
            );
        }

    }
}

