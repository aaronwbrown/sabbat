using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoordinateSystem
{
    class GetCoordinates
    {
        public static List<List<Array>> Coordinates (int rows, int cols, int max)
        { 
            List<List<Array>> matrixList = new List<List<Array>>();
            for (int i = 0; i < rows; i++)
            {
                List<Array> coordinateList = new List<Array>();
                for (int j = 0; j < cols; j++)
                {
                    List<int> coordinates = GetCoordinate(i, j, max);
                    coordinateList.Add(coordinates.ToArray());
                }
                matrixList.Add(coordinateList);
            }
            return matrixList;
        }

        private static List<int> GetCoordinate(int iIndex, int jIndex, int max)
        {
            List<int> coordinateList = new List<int>();
            coordinateList.Add(GetX(jIndex));
            coordinateList.Add(0);
            coordinateList.Add(GetY(iIndex, max));
            return coordinateList;
        }
        
        private static int GetX(int jIndex)
        {
            return jIndex - 2;
        }

        private static int GetY(int iIndex, int max)
        {
            return (iIndex + 2) > (max -1) ? iIndex - 2 : iIndex + 2;
        }
    }
}
