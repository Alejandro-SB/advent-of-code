using AdventOfCode2019.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Days
{
    public static class Day3
    {
        public async static Task<int> Part1()
        {
            var input = await GetInputFromFile();
            var path1 = input[0];
            var path2 = input[1];

            return GetCrossingDistanceForPaths(path1, path2);
        }

        public async static Task<int> Part2()
        {
            var input = await GetInputFromFile();
            var path1 = input[0];
            var path2 = input[1];

            return GetMinimumTimingForPaths(path1, path2);
        }

        public static int GetCrossingDistanceForPaths(string path1, string path2)
        {
            var pointsPath1 = GetVisitedPoints(path1);
            var pointsPath2 = GetVisitedPoints(path2);

            var repeatedPoints = pointsPath1.Intersect(pointsPath2);

            var minimum = repeatedPoints.Where(x => x.X != 0 && x.Y != 0).Min(p => p.ManhattanDistance);

            return minimum;
        }

        public static int GetMinimumTimingForPaths(string path1, string path2)
        {
            var pointsPath1 = GetVisitedPoints(path1);
            var pointsPath2 = GetVisitedPoints(path2);

            var repeatedPoints = pointsPath1.Intersect(pointsPath2);

            var minimum = repeatedPoints.Where(x => x.X != 0 && x.Y != 0).Min(p =>
            {
                var p1 = pointsPath1.IndexOf(p);
                var p2 = pointsPath2.IndexOf(p);

                return p1 + p2;
            });

            return minimum;
        }

        private async static Task<string[]> GetInputFromFile()
        {
            var lines = await FileHelper.GetInputLinesAsync("3.txt");

            return lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        }

        private static List<Point> GetVisitedPoints(string path)
        {
            var movements = path.Split(',');

            var points = new List<Point>
            {
                new Point(0, 0)
            };

            foreach (var movement in movements)
            {
                char direction = movement[0];
                int steps = int.Parse(movement.Substring(1));

                var lastPoint = points.Last();

                points.AddRange(GeneratePointsFromPrevious(direction, steps, lastPoint));
            }

            return points;
        }

        private static IEnumerable<Point> GeneratePointsFromPrevious(char direction, int steps, Point previous)
        {
            var points = new List<Point>();

            switch (direction)
            {
                case 'R':
                    for (int i = 1; i <= steps; ++i)
                    {
                        points.Add(new Point(previous.X + i, previous.Y));
                    }
                    break;
                case 'L':
                    for (int i = 1; i <= steps; ++i)
                    {
                        points.Add(new Point(previous.X - i, previous.Y));
                    }
                    break;
                case 'U':
                    for (int i = 1; i <= steps; ++i)
                    {
                        points.Add(new Point(previous.X, previous.Y + i));
                    }
                    break;
                case 'D':
                    for (int i = 1; i <= steps; ++i)
                    {
                        points.Add(new Point(previous.X, previous.Y - i));
                    }
                    break;
            }

            return points;
        }

        class Point : IEquatable<Point>
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int ManhattanDistance
            {
                get
                {
                    return Math.Abs(X) + Math.Abs(Y);
                }
            }

            public bool Equals([AllowNull] Point other)
            {
                return other.X == this.X && other.Y == this.Y;
            }

            public override bool Equals(object obj)
            {
                return obj != null && obj is Point && this.Equals((Point)obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }
        }
    }
}