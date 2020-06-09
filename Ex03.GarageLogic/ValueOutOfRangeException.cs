﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception 
    {
        private float m_MinValue;
        private float m_MaxValue;



        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            :base()
        {
            this.m_MaxValue = i_MaxValue;
            this.m_MinValue = i_MinValue;
        }
    }
}
