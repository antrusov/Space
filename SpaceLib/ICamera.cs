using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XnaGeometry;

namespace Space
{
    public interface ICamera
    {

        /// <summary>
        /// итоговая матрица проецирования
        /// </summary>
        XnaGeometry.Matrix Matrix { get; }

        /// <summary>
        /// матрица проецирования в виде массива (для передачи в методы GL)
        /// </summary>
        double[] MatrixArray { get; }

        /// <summary>
        /// управление камерой
        /// </summary>
        /// <param name="name">название команды перемещения (поворот, движение, масштабирование и т.п.)</param>
        /// <param name="arg">аргумент команды (величина сдвига, поворота и т.п.)</param>
        void Move(string name, double arg);
    }
}
