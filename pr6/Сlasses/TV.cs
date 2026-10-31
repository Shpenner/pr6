
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace pr6.Сlasses
{
    public class TV
    {
        private int activeChanell;
        private int activeVolume;

        public int ActiveChanell
        {
            get { return activeChanell; }
            set
            {
                if (activeChanell < AllChanells.Count - 1)
                {
                    activeChanell = value;
                }
                else
                    activeChanell = 0;

                if (activeChanell < 0)
                    activeChanell = AllChanells.Count - 1;
            }
        }

        public List<Chanell> AllChanells = new List<Chanell>();

        public TV()
        {
            AllChanells.Add(new Chanell()
            {
                Name = "Городские небоскрёбы",
                Src = ""
            });
            AllChanells.Add(new Chanell()
            {
                Name = "Автомобильное шоссе",
                Src = ""
            });
            AllChanells.Add(new Chanell()
            {
                Name = "Природа",
                Src = ""
            });
        }

        public void SwapChanell(MediaElement mediaElement, Label nameChanell)
        {
            DoubleAnimation startAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.6)
            };
            startAnimation.Completed += delegate
            {
                mediaElement.Source = new Uri(AllChanells[ActiveChanell].Src);
                mediaElement.Play();

                DoubleAnimation endAnimation = new DoubleAnimation()
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.6)
                };
                mediaElement.BeginAnimation(MediaElement.OpacityProperty, endAnimation);
            };
            
            mediaElement.BeginAnimation(MediaElement.OpacityProperty, startAnimation);
            nameChanell.Content = AllChanells[ActiveChanell].Name;
        }

        public void NextChanell(MediaElement mediaElement, Label nameChanell)
        {
            ActiveChanell++;
            SwapChanell(mediaElement, nameChanell);
        }

        public void BackChanell(MediaElement mediaElement, Label nameChanell)
        {
            ActiveChanell--;
            SwapChanell(mediaElement, nameChanell);
        }

        public void Upound()
        {

        }

        public void DownSound()
        {

        }
    }
}
