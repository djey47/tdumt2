using System;

namespace DjeLibrary_2.Systems
{
    /// <summary>
    /// Make calculations and transformations based on binary representation
    /// </summary>
    public static class BitUtils
    {
        #region Méthodes publiques
        /// <summary>
        /// Convertit la valeur Little Endian en Big Endian
        /// </summary>
        /// <param name="valueToConvert"></param>
        /// <returns></returns>
        public static uint ToBigEndian(uint valueToConvert)
        {
            return _SwitchEndianType(valueToConvert);
        }

        /// <summary>
        /// Convertit la valeur Big Endian en Little Endian
        /// </summary>
        /// <param name="valueToConvert"></param>
        /// <returns></returns>
        public static uint ToLittleEndian(uint valueToConvert)
        {
            return _SwitchEndianType(valueToConvert);
        }

        /// <summary>
        /// Converts short value from Little Endian to Big Endian
        /// </summary>
        /// <param name="valueToConvert"></param>
        /// <returns></returns>
        public static short ToBigEndian(short valueToConvert)
        {
            return _SwitchEndianType(valueToConvert);
        }

        /// <summary>
        /// Converts short value from Big Endian to Little Endian
        /// </summary>
        /// <param name="valueToConvert"></param>
        /// <returns></returns>
        public static short ToLittleEndian(short valueToConvert)
        {
            return _SwitchEndianType(valueToConvert);
        }
        #endregion

        #region Méthodes privées
        /// <summary>
        /// Conversion du type d'endian little endian vers big endian et réciproquement
        /// </summary>
        /// <param name="valueToSwitch">Valeur à convertir</param>
        /// <returns>La valeur avec type endian inverse</returns>
        private static uint _SwitchEndianType(uint valueToSwitch)
        {
            UInt32 response =
                (valueToSwitch >> 24) |
                ((valueToSwitch << 8) & 0x00FF0000) |
                ((valueToSwitch >> 8) & 0x0000FF00) |
                (valueToSwitch << 24);

            return response;
        }

        /// <summary>
        /// Converts endian type : little endian to big endian and reversely
        /// </summary>
        /// <param name="valueToSwitch"></param>
        /// <returns></returns>
        private static short _SwitchEndianType(short valueToSwitch)
        {
            byte[] temp = BitConverter.GetBytes(valueToSwitch);

            Array.Reverse(temp);

            return BitConverter.ToInt16(temp, 0);
        }
        #endregion
    }
}
