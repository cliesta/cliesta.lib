#region copyright

// This software program (`The Software') is the proprietary product of ASM
// Assembly Systems Weymouth Limited and is protected by copyright laws and
// international treaty. You must treat the software like any other
// copyrighted material, except that you may make one copy of the software
// solely for backup or archival purposes. Copyright laws prohibit making
// additional copies of the software for any other reasons. You may not copy
// the written materials accompanying the software.
// Copyright (c) 2021 ASM Assembly Systems Weymouth Limited, All Rights Reserved.

#endregion

using System.Diagnostics.CodeAnalysis;
using Cliesta.Lib2.Geometry;
using NUnit.Framework;

namespace DoctorPrint.Lib.Tests.Generic
{
    [ExcludeFromCodeCoverage]
    public class Point2DTests
    {
        [TestCase( 0, 0, 0, 0, true )]
        [TestCase( 0, 1, 0, 1, true )]
        [TestCase( 1, 1, 1, 1, true )]
        [TestCase( 1, 0, 1, 0, true )]
        [TestCase( 0, 0, 0, 1, false )]
        [TestCase( 0, 1, 1, 1, false )]
        [TestCase( 1, 0, 1, 1, false )]
        [TestCase( 0, 0, 1, 0, false )]
        public void Point2DEquality( double x1, double y1, double x2, double y2, bool shouldBeEqual )
        {
            var point1 = new Point2D( x1, y1 );
            var point2 = new Point2D( x2, y2 );
            if ( shouldBeEqual )
            {
                Assert.AreEqual( point1, point2 );
            }
            else
            {
                Assert.AreNotEqual( point1, point2 );
            }
        }
    }
}