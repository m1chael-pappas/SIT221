using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FungusInfestation
{
    public class FungusInfestation
    {
        public static int Solve(string[] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                throw new ArgumentException("Matrix cannot be null or empty.");

            int R = matrix.Length;
            int C = matrix[0].Length;

            for (int i = 0; i < R; i++)
            {
                if (matrix[i] == null || matrix[i].Length != C)
                    throw new ArgumentException("All rows must be non-null and the same length.");
            }

            int[] dr = { -1, 1, 0, 0 };
            int[] dc = { 0, 0, -1, 1 };

            // fungusTime[r,c] = earliest time fungus reaches cell (r,c), int.MaxValue if never
            int[,] fungusTime = new int[R, C];
            for (int r = 0; r < R; r++)
            for (int c = 0; c < C; c++)
                fungusTime[r, c] = int.MaxValue;

            Queue<(int r, int c)> fungusQueue = new Queue<(int, int)>();
            int startR = -1,
                startC = -1;

            // Initialize: find all F sources and player position
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (matrix[r][c] == 'F')
                    {
                        fungusTime[r, c] = 0;
                        fungusQueue.Enqueue((r, c));
                    }
                    else if (matrix[r][c] == '$')
                    {
                        startR = r;
                        startC = c;
                    }
                }
            }

            if (startR == -1 || startC == -1)
                throw new ArgumentException("Matrix must contain a player '$' cell.");

            // No fungus at all means the player survives indefinitely
            if (fungusQueue.Count == 0)
                return -1;

            // BFS to compute fungus spread times
            while (fungusQueue.Count > 0)
            {
                var (cr, cc) = fungusQueue.Dequeue();
                int t = fungusTime[cr, cc];

                for (int d = 0; d < 4; d++)
                {
                    int nr = cr + dr[d];
                    int nc = cc + dc[d];
                    if (
                        nr >= 0
                        && nr < R
                        && nc >= 0
                        && nc < C
                        && matrix[nr][nc] != '#'
                        && fungusTime[nr, nc] > t + 1
                    )
                    {
                        fungusTime[nr, nc] = t + 1;
                        fungusQueue.Enqueue((nr, nc));
                    }
                }
            }

            // BFS from player position
            // playerTime[r,c] = earliest time player can reach cell (r,c)
            int[,] playerTime = new int[R, C];
            for (int r = 0; r < R; r++)
            for (int c = 0; c < C; c++)
                playerTime[r, c] = int.MaxValue;

            // Check player start is not already infected at time 0
            if (fungusTime[startR, startC] == 0)
                return 0;

            playerTime[startR, startC] = 0;
            Queue<(int r, int c)> playerQueue = new Queue<(int, int)>();
            playerQueue.Enqueue((startR, startC));

            int maxSurvival = 0;
            bool canSurviveForever = false;

            while (playerQueue.Count > 0)
            {
                var (cr, cc) = playerQueue.Dequeue();
                int t = playerTime[cr, cc];

                // Player survives at this cell until fungus arrives (or forever)
                if (fungusTime[cr, cc] == int.MaxValue)
                {
                    canSurviveForever = true;
                    break;
                }

                // Player survives fungusTime[cr,cc] hours at this cell (hours 0..fungusTime-1)
                int surviveHere = fungusTime[cr, cc];
                if (surviveHere > maxSurvival)
                    maxSurvival = surviveHere;

                for (int d = 0; d < 4; d++)
                {
                    int nr = cr + dr[d];
                    int nc = cc + dc[d];
                    if (
                        nr >= 0
                        && nr < R
                        && nc >= 0
                        && nc < C
                        && matrix[nr][nc] != '#'
                        && playerTime[nr, nc] > t + 1
                        && fungusTime[nr, nc] > t + 1
                    )
                    {
                        playerTime[nr, nc] = t + 1;
                        playerQueue.Enqueue((nr, nc));
                    }
                }
            }

            if (canSurviveForever)
                return -1;

            return maxSurvival;
        }
    }
}
