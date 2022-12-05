using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace ShatterWorldBattleServer
{
    public class TurnManager
    {
        private Dictionary<int, Agent> _agentSpeedList;
        private int agentPlayingId;

        private int Threshold = 100;

        public TurnManager()
        {
            _agentSpeedList = new Dictionary<int, Agent>();
            agentPlayingId = 0;
        }

        /// <summary>
        ///  The function calculates which is the agent that will take less turns to achieve the Threshold.
        ///  It stores both values the agent and how many turns it will take to play.
        ///  Obs: the "turns" is a float number
        /// </summary>
        /// <returns> The id of the agent that will play next turn</returns>
        public int CalculateNextTurn()
        {
            int nextToPlay = 0; //Intiallize so it can be used above on ErasePoints -- but is sure that it will be modified on the for
            float closerNumberOfTurns = 100000;
            foreach (Agent agent in _agentSpeedList.Values)
            {
                float missingTurns = agent.TurnsMissingToPlay(Threshold);
                if(missingTurns < closerNumberOfTurns )
                {
                    closerNumberOfTurns = missingTurns;
                    nextToPlay = agent.GetAgentId();    
                }
            }
            
            UpdateAllTurnPoints(closerNumberOfTurns);
            Console.WriteLine("NextToPlat: " + nextToPlay);
            _agentSpeedList[nextToPlay].ErasePoints();
            agentPlayingId = nextToPlay;
            
            

            return agentPlayingId;
        }

        public void UpdateAllTurnPoints(float closerNumberOfTurns)
        {
            foreach (Agent agentSpeed in _agentSpeedList.Values)
            {
                agentSpeed.CalculatePoints(closerNumberOfTurns);
            }
        }

        public void AddAgents(List<Agent> agents)
        {
            foreach (Agent agent in agents)
            {
                _agentSpeedList.Add(agent.GetAgentId(), agent);
            }
        }

        public void EndTurn(int agentId)
        {
            if (agentId == agentPlayingId)
            {
                agentPlayingId = 0;
            }
            else
            {
                //Throw error 
            }

        }



    }

}