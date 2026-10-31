
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
                Src = "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Cityscape_at_dusk__SaveYouTube_com_.mp4"
            });
            AllChanells.Add(new Chanell()
            {
                Name = "Автомобильное шоссе",
                Src = "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Cars_driving_at_night__SaveYouTube_com_.mp4"
            });
            AllChanells.Add(new Chanell()
            {
                Name = "Природа",
                Src = "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\SunRaysinForest.mp4"
            });
            AllChanells.Add(new Chanell()
            {
                Name = "Природа",
                Src = "C:\\Users\\student-a502.PERMAVIAT\\Downloads\\Kai Angel – welcome to forever (English Subtitles)_720p.mp4"
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

        public void UpSound(MediaElement mediaElement)
        {
            mediaElement.Volume += 0.1;
        }

        public void DownSound(MediaElement mediaElement)
        {
            mediaElement.Volume -= 0.1;
        }
    }
}
