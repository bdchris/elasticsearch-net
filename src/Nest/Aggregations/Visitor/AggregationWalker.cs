// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;

namespace Nest
{
	public class AggregationWalker
	{
		private void Accept(IAggregationVisitor visitor, AggregationDictionary aggregations)
		{
			if (!aggregations.HasAny()) return;

			foreach (var f in aggregations)
				Accept(visitor, f.Value, AggregationVisitorScope.Bucket);
		}

		private void Accept(IAggregationVisitor visitor, IAggregationContainer aggregation,
			AggregationVisitorScope scope = AggregationVisitorScope.Aggregation
		)
		{
			if (aggregation == null) return;

			visitor.Scope = scope;
			aggregation.Accept(visitor);
		}

		private static void AcceptAggregation<T>(T aggregation, IAggregationVisitor visitor, Action<IAggregationVisitor, T> scoped)
			where T : class, IAggregation
		{
			if (aggregation == null) return;

			visitor.Depth = visitor.Depth + 1;
			visitor.Visit(aggregation);
			scoped(visitor, aggregation);
			visitor.Depth = visitor.Depth - 1;
		}

		public void Walk(IAggregationContainer aggregation, IAggregationVisitor visitor)
		{
			visitor.Visit(aggregation);
			AcceptAggregation(aggregation.Average, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.AverageBucket, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.Boxplot, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.BucketScript, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.BucketSort, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.BucketSelector, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.Cardinality, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.Children, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.CumulativeSum, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.CumulativeCardinality, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.DateHistogram, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.DateRange, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.Derivative, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.ExtendedStats, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.Filter, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.Filters, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.GeoBounds, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.GeoDistance, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.GeoHash, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.GeoLine, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.GeoTile, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.Global, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.Histogram, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.IpRange, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.Max, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.MaxBucket, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.Min, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.MinBucket, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.Missing, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.MovingAverage, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.MovingPercentiles, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.MultiTerms, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.Nested, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.Normalize, visitor, (v, d) =>
			{
				v.Visit(d);
			});
			AcceptAggregation(aggregation.Parent, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.PercentileRanks, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.Percentiles, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.Range, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.RareTerms, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.Rate, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.ReverseNested, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.Sampler, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.ScriptedMetric, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.SerialDifferencing, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.SignificantTerms, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.SignificantText, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.Stats, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.Sum, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.SumBucket, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.StatsBucket, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.ExtendedStatsBucket, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.PercentilesBucket, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.Terms, visitor, (v, d) =>
			{
				v.Visit(d);
				Accept(v, d.Aggregations);
			});
			AcceptAggregation(aggregation.TopHits, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.ValueCount, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.GeoCentroid, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.Composite, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.MedianAbsoluteDeviation, visitor, (v, d) => v.Visit(d));
			AcceptAggregation(aggregation.TTest, visitor, (v, d) => v.Visit(d));
		}
	}
}
