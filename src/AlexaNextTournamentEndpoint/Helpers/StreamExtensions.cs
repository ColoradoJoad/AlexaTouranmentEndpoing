using System.IO;

namespace AlexaNextTournamentEndpoint.Helpers
{
    public static class StreamExtensions
    {
        public static byte[] ReadToEnd(this Stream input)
        {
            long lenth = input.Length;
            long remaining = lenth;

            byte[] data = new byte[remaining];
            input.Read(data, 0, (int)remaining);
            return data;
        }

        public static string ReadAsString(this Stream input)
        {
            using (StreamReader reader = new StreamReader(input))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
