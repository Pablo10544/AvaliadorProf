using AvaliadorProf.MVVM.Models;
using PanCardView.EventArgs;
using System;
using System.Globalization;

namespace AvaliadorProf
{
   
        public class SwipeDirectionWithIdConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is ItemSwipedEventArgs args && args.Item is CardProfessor card)
                {
                    return new
                    {
                        Direction = args.Direction,
                        CardId = card.Id
                    };
                }
                return null;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
