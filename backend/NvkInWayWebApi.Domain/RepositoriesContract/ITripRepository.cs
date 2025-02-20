﻿using NvkInWayWebApi.Domain.Models;

namespace NvkInWayWebApi.Domain.RepositoriesContract
{
    public interface ITripRepository
    {
        public Task<OperationResult<List<Trip>>> GetTripsByDriverIdAsync(long driverId, int startIndex, int count);

        public Task<OperationResult<List<Trip>>> GetTripsByPassengerIdAsync(long passengerId, int startIndex, int count);

        public Task<OperationResult<List<Trip>>> GetActiveTripsByDriverIdAsync(long driverId, int startIndex, int count);

        public Task<OperationResult<List<Trip>>> GetActiveTripsByPassengerIdAsync(long passengerId, int startIndex, int count);

        public Task<OperationResult<List<Trip>>> GetTripsByIntervalAsync(
            TripSearchInterval searchDto, int startIndex, int count);

        public Task<OperationResult<Trip>> GetTripByTripIdAsync(Guid tripId);

        public Task<OperationResult> AddTripAsync(Trip trip);

        public Task<OperationResult> UpdateTripAsync(Trip trip);

        public Task<OperationResult> DeleteTripAsync(Guid id);

        public Task<OperationResult> RecordToTripAsync(Record record);

        public Task<OperationResult> CompleteTripAsync(Trip trip);

        public Task<OperationResult> RateParticipantAsync(Guid tripId, long raterId, long targetId, float? rating);

        public Task<OperationResult<Dictionary<Trip, List<long>>>> GetNotifyingProfilesFromTrips(int startTripIndex, int tripCount);
    }
}
