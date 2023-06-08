using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tanks
{
    public class Tank : MonoBehaviour, IPartInstaller
    {
        private IBody body;

        private List<ITrack> leftTracks = new List<ITrack>();
        private List<ITrack> rightTracks = new List<ITrack>();


        public void InstallPart(IPart part)
        {
            part.Accept(this);
        }


        private List<PartPair> pairs = new List<PartPair>();

        private bool CreatePair(IPart parent, IPart child)
        {
            if(PartPair.TryCreate(out PartPair pair, parent, child))
            {
                pairs.Add(pair);
                return true;
            }
            return false;
        }
        

        public void Install(IBody body)
        {
            this.body = body;
        }
        public void Install(ITrack track)
        {
            if(track.Transform.localPosition.x > 0)
            {
                rightTracks.Add(track);
            }
            else
            {
                leftTracks.Add(track);
            }

            CreatePair(body, track);
        }
    }
}
