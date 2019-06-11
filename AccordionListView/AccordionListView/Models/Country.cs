﻿using AccordionListView.Custom;
using AccordionListView.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AccordionListView.Models
{
    public class City : BaseViewModel
    {
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public bool IsCChildrenVisible { get; set; }
        public string ArrowIconSource
        {
            get
            {
                if (States != null)
                {
                    if (IsCChildrenVisible)
                        return "uparrow.png";
                    else
                        return "downarrow.png";
                }
                else
                    return "rightarrow.png";
            }
        }
        public ObservableCollection<State> States { get; set; }
        private int _ChildrenRowHeightRequest;
        public int ChildrenRowHeightRequest
        {
            get
            {
                if (States != null)
                {
                    _ChildrenRowHeightRequest = States.Count * 65;
                    return _ChildrenRowHeightRequest;
                }
                else
                    return 0;
            }
            set => SetProperty(ref _ChildrenRowHeightRequest, value);
        }
    }

    public class State
    {
        public string StateName { get; set; }
        public string StateCode { get; set; }
    }

    public class Country : BaseViewModel
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public bool IsChildrenVisible { get; set; }
        public string ArrowIconSource
        {
            get
            {
                if (Cities != null)
                {
                    if (IsChildrenVisible)
                        return "uparrow.png";
                    else
                        return "downarrow.png";
                }
                else
                    return "rightarrow.png";
            }
        }
        private CustomObservableCollection<City> cities;
        public CustomObservableCollection<City> Cities
        {
            get => cities;
            set => SetProperty(ref cities, value);
        }

        private int _ChildrenRowHeightRequest;
        public int ChildrenRowHeightRequest
        {
            get
            {
                if (Cities != null)
                {
                    _ChildrenRowHeightRequest = Cities.Count * 65 + (_ChildrenRowHeightRequest * 65);
                    return _ChildrenRowHeightRequest;
                }
                else
                    return 0;
            }
            //get { return _ChildrenRowHeightRequest; }
            set => SetProperty(ref _ChildrenRowHeightRequest, value);
        }
    }
}
