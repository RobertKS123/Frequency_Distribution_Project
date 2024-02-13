using System;

namespace frequency_distribution
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tower> towers = new List<Tower>
            {
                new Tower("A", 536660, 183800, -0.03098, 51.53657),
                new Tower("B", 537032, 184006, -0.02554, 51.53833),
                new Tower("C", 537109, 183884, -0.02448, 51.53721),
                new Tower("D", 537110, 184695, -0.02415, 51.5445),
                new Tower("E", 537206, 184685, -0.02277, 51.54439),
                new Tower("F", 537248, 185016, -0.02204, 51.54735),
                new Tower("G", 537250, 185020, -0.02201, 51.54739),
                new Tower("H", 537267, 184783, -0.02185, 51.54525),
                new Tower("I", 537269, 183451, -0.02234, 51.53328),
                new Tower("J", 537270, 184140, -0.02206, 51.53948),
                new Tower("K", 537356, 184927, -0.02052, 51.54653),
                new Tower("L", 537380, 184727, -0.02025, 51.54472),
                new Tower("M", 537458, 184495, -0.01921, 51.54262),
                new Tower("N", 537604, 184134, -0.01725, 51.53934),
                new Tower("O", 537720, 184057, -0.01561, 51.53862),
                new Tower("P", 537905, 184591, -0.01273, 51.54337),
                new Tower("Q", 537910, 184441, -0.01272, 51.54202),
                new Tower("R", 537953, 184295, -0.01216, 51.5407),
                new Tower("S", 538050, 184245, -0.01078, 51.54023)
            };

            //come up with a good way of getting the sort distance

            createVertices(towers);

            // get target with the most neighbors as the start point for the graph search
            Tower mostNeighbors = towers.Aggregate((a, b) => (a.Neighbors.Count > b.Neighbors.Count ? a : b));

            
        }
    }

    // Create some vertices of nearby Cell towers to speed up computation
    public void createVertices (List<Tower> towers) {
        double sortDistance = 0.5;
        double smallestDistance = double.MaxValue;
        Tower closestNeighbor = null;
        for (int i = 0; i<towers.Count-1; i++) {
            Tower tower1 = towers[i];
            for(int j = i+1; j < towers.Count; j++ ) {
                Tower tower2 = towers[j];
                double distance = getDistance(tower1,tower2);
                if (distance <= sortDistance)  
                {
                    tower1.addNeighbor(tower2);
                    tower2.addNeighbor(tower1);
                }
                if (distance < smallestDistance) {
                    smallestDistance = distance;
                    closestNeighbor = tower2;
                }
            }
            // ensure that each tower has at least one neighbor
            if (tower1.neighbors.Count == 0 && closestNeighbor != null) {
                    tower1.addNeighbor(closestNeighbor);
                    closestNeighbor.addNeighbor(tower1);
            }
        }
    } 

    //Manhattan Distance 
    public double getDistance(Tower a, Tower b) {
        return Math.Abs(a.Long - b.Long) + Math.Abs(a.Lat - b.Lat);
    }

    // Object to hold the Cell Towers
    class Tower 
    {
        //set criteria
        private char Name {get;}
        private double Easting {get;}
        private double Northing {get;}
        private double Long {get;}
        private double Lat {get;}

        //changeable criteria
        private int Color {get;set;}
        private  List<Tower> Neighbors {get;}

        Tower(char name, double easting, double northing, double longitude, double lat)
        {
            Name = name;
            Easting = easting;
            Northing = northing;
            Long = longitude;
            Lat = lat;
        }

        public addNeighbor(Tower t) {
            Neighbors.Add(t);
        }

    }

    public class SearchTree {
        private Tower root {get;set;}

        Sea
    }
}
