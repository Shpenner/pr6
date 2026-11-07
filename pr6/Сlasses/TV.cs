
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace pr6.Сlasses
{
    public class TV
    {
        private int activeChanell;
        private int activeVolume;
        private int activeSrc;

        public int ActiveSrc
        {
            get { return activeSrc; }
            set
            {
                if (activeSrc < AllChanells[ActiveChanell].Src.Count - 1)
                {
                    activeSrc = value;
                }
                else
                    activeSrc = 0;

                if (activeSrc < 0)
                    activeSrc = AllChanells[ActiveChanell].Src.Count - 1;
            }
        }

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
                Src = { "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Новая папка (3)\\pr6\\Videos\\skyscaper.mp4", 
                    "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Новая папка (3)\\pr6\\Videos\\scyscaper2.mp4",
                    "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Новая папка (3)\\pr6\\Videos\\scyscaper3.mp4"}
            });
            AllChanells.Add(new Chanell()
            {
                Name = "Автомобильное шоссе",
                Src = { "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Новая папка (3)\\pr6\\Videos\\road.mp4", 
                    "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Новая папка (3)\\pr6\\Videos\\road3.mp4", 
                    "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Новая папка (3)\\pr6\\Videos\\road2.mp4" }
            });
            AllChanells.Add(new Chanell()
            {
                Name = "Природа",
                Src = { "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Новая папка (3)\\pr6\\Videos\\forest.mp4", 
                    "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Новая папка (3)\\pr6\\Videos\\forest3.mp4", 
                    "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Новая папка (3)\\pr6\\Videos\\fores2.mp4" }
            });
            AllChanells.Add(new Chanell()
            {
                Name = "Мультики",
                Src = { "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Новая папка (3)\\pr6\\Videos\\barbariki.mp4", 
                    "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Новая папка (3)\\pr6\\Videos\\ot_vinta.mp4",
                    "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Новая папка (3)\\pr6\\Videos\\bremen.mp4"}
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
                mediaElement.Source = new Uri(AllChanells[ActiveChanell].Src[0]);
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

        public void SelectChanel(MediaElement mediaElement, Label nameChanell, int x)
        {
            if (x > AllChanells.Count || x < 0) return;
            else ActiveChanell = x - 1;
            SwapChanell(mediaElement, nameChanell);
        }

        public void UpSound(MediaElement mediaElement)
        {
            mediaElement.Volume += 0.1;
        }

        public void DownSound(MediaElement mediaElement)
        {
            mediaElement.Volume -= 0.1;
        }

        public void NextShow(MediaElement mediaElement, Label nameChanell)
        {
            ActiveSrc++;
            mediaElement.Source = new Uri(AllChanells[ActiveChanell].Src[ActiveSrc]);
        }

        public void BackShow(MediaElement mediaElement, Label nameChanell)
        {
            ActiveSrc--;
            mediaElement.Source = new Uri(AllChanells[ActiveChanell].Src[ActiveSrc]);
        }
    }
}
