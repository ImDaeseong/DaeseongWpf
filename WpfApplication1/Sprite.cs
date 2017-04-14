using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Reflection;

namespace WpfApplication1
{
    public class SpriteManager
    {
        private static Dictionary<string, Sprite> mSprites;

        static SpriteManager()
        {
            mSprites = new Dictionary<string, Sprite>();
        }

        public static Sprite GetSprite(string sPath)
        {
            Sprite sp;
            if(!mSprites.TryGetValue(sPath, out sp))
            {
                var img = new BitmapImage(new Uri(sPath, UriKind.Relative));
                sp = new Sprite(img);
                mSprites[sPath] = sp;
            }
            return sp;
        }

    }

    public class Sprite
    {
        private BitmapImage mbitmap;

        public Image Image { get; private set; }

        public Sprite(BitmapImage bitmap)
        {
            Image = new Image();
            Image.Source = bitmap;

            mbitmap = bitmap;

            //sprite image
            GetCroppedImageList(3, 5);
        }

        
        private List<CroppedBitmap> Spriteslst = new List<CroppedBitmap>();
        private void GetCroppedImageList(int rows, int columns)
        {
            var sourceWidth = mbitmap.PixelWidth / columns;
            var sourceHeight = mbitmap.PixelHeight / rows;

            var sources = new CroppedBitmap[rows * columns];
            for (var index = 0; index < sources.Count(); index++)
            {
                var xPosition = (index % columns) * sourceWidth;
                var yPosition = (index / columns) * sourceHeight;

                var croppedBitmap = new CroppedBitmap();
                croppedBitmap.BeginInit();
                croppedBitmap.Source = mbitmap;
                croppedBitmap.SourceRect = new Int32Rect(xPosition, yPosition, sourceWidth, sourceHeight);
                croppedBitmap.EndInit();

                Spriteslst.Add(croppedBitmap);
            }
        }

        public void Visible(bool bShow)
        {
            if(bShow)
                Image.Visibility = Visibility.Visible;
            else
                Image.Visibility = Visibility.Hidden;
        }

        private static int mIndex = 0;
        public void Move(int nX, int nY)
        {
            //원본 이미지
            //Image.Margin = new Thickness(nX, nY, 0, 0);

            if ((Spriteslst.Count-1) == mIndex )
                mIndex = 0;
            else
                mIndex++;
                        
            //자른 이미지
            Image.Source = Spriteslst[mIndex];
            Image.Margin = new Thickness(nX, nY, 0, 0);
        }
    }
    
}
