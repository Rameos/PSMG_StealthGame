using System;
using UnityEngine; 

    /// <summary>
    /// Einfache Klasse, die Anfangspunkt, Endpunkt und das Volumen der Rechteckigen AOI speichert
    /// </summary>
    class AOI
    {
        public Rect volume { get; set;}
        public Vector3 startPoint { get; set;}
        public Vector3 endPoint { get; set;}


        public AOI(Rect volume, Vector3 startPoint, Vector3 endPoint)
        {
            this.volume = volume;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }
    }
