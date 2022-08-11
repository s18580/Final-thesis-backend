﻿using Application.Functions.DTOs.DTOsValidators;
using Application.Services;
using MediatR;

namespace Application.Functions.Order.Commands.CreateOrderWithDataCommand
{
    public class CreateOrderWithDataCommandHandler : IRequestHandler<CreateOrderWithDataCommand, CreateOrderWithDataResponse>
    {
        private readonly IApplicationContext _context;

        public CreateOrderWithDataCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<CreateOrderWithDataResponse> Handle(CreateOrderWithDataCommand request, CancellationToken cancellationToken)
        {
            // create validators
            var orderValidator = new CreateOrderWithDataValidator(_context);
            var addressValidator = new AddressDTOValidator();
            var orderItemValidator = new OrderItemDTOValidator(_context);
            var workerAssignmentValidator = new WorkerAssignmentDTOValidator(_context);
            var paperValidator = new PaperDTOValidator(_context);
            var serviceValidator = new ServiceDTOValidator(_context);

            // validate data
            var orderValidatorResult = await orderValidator.ValidateAsync(request);
            if (!orderValidatorResult.IsValid) return new CreateOrderWithDataResponse(orderValidatorResult, Responses.ResponseStatus.ValidationError);

            foreach (var address in request.DeliveryAddresses)
            {
                var addressValidatorResult = await addressValidator.ValidateAsync(address);
                if (!addressValidatorResult.IsValid) return new CreateOrderWithDataResponse(addressValidatorResult, Responses.ResponseStatus.ValidationError);
            }

            foreach (var orderItem in request.OrderItems)
            {
                var orderItemValidatorResult = await orderItemValidator.ValidateAsync(orderItem);
                if (!orderItemValidatorResult.IsValid) return new CreateOrderWithDataResponse(orderItemValidatorResult, Responses.ResponseStatus.ValidationError);

                foreach (var paper in orderItem.Papers)
                {
                    var paperValidatorResult = await paperValidator.ValidateAsync(paper);
                    if (!paperValidatorResult.IsValid) return new CreateOrderWithDataResponse(paperValidatorResult, Responses.ResponseStatus.ValidationError);
                }

                foreach (var service in orderItem.Services)
                {
                    var serviceValidatorResult = await serviceValidator.ValidateAsync(service);
                    if (!serviceValidatorResult.IsValid) return new CreateOrderWithDataResponse(serviceValidatorResult, Responses.ResponseStatus.ValidationError);
                }
            }

            foreach (var workerAssignment in request.WorkersToAssign)
            {
                var workerAssignmentValidatorResult = await workerAssignmentValidator.ValidateAsync(workerAssignment);
                if (!workerAssignmentValidatorResult.IsValid) return new CreateOrderWithDataResponse(workerAssignmentValidatorResult, Responses.ResponseStatus.ValidationError);
            }

            // create objects in transaction
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                var newOrder = new Domain.Models.Order
                {
                    Name = request.Name,
                    CreationDate = DateTime.Now,
                    Identifier = "SomeBuissnesIdentifier",
                    OrderSubmissionDate = request.OrderSubmissionDate,
                    Note = request.Note,
                    IsAuction = request.IsAuction,
                    ExpectedDeliveryDate = request.ExpectedDeliveryDate,
                    DeliveryDate = null,
                    OfferValidityDate = request.OfferValidityDate,
                    IdRepresentative = request.IdRepresentative,
                    IdStatus = request.IdStatus,
                };

                await _context.Orders.AddAsync(newOrder);
                await _context.SaveChangesAsync();

                foreach (var address in request.DeliveryAddresses)
                {
                    var newAddress = new Domain.Models.Address
                    {
                        Name = address.Name,
                        City = address.City,
                        Country = address.Country,
                        PostCode = address.PostCode,
                        StreetName = address.StreetName,
                        StreetNumber = address.StreetNumber,
                        ApartmentNumber = address.ApartmentNumber,
                        IdSupplier = null,
                        IdCustomer = request.IdCustomer,
                    };

                    await _context.Addresses.AddAsync(newAddress);
                    await _context.SaveChangesAsync();
                }

                foreach (var orderItem in request.OrderItems)
                {
                    var newOrderItem = new Domain.Models.OrderItem
                    {
                        IdOrder = newOrder.IdOrder,
                        Circulation = orderItem.Circulation,
                        Capacity = orderItem.Capacity,
                        Name = orderItem.Name,
                        Comments = orderItem.Comments,
                        ExpectedCompletionDate = orderItem.ExpectedCompletionDate,
                        CompletionDate = orderItem.CompletionDate,
                        InsideFormat = orderItem.InsideFormat,
                        CoverFormat = orderItem.CoverFormat,
                        IdSelectedValuation = null,
                        IdDeliveryType = orderItem.IdDeliveryType,
                        IdBindingType = orderItem.IdBindingType,
                        IdOrderItemType = orderItem.IdOrderItemType,
                    };

                    await _context.OrderItems.AddAsync(newOrderItem);
                    await _context.SaveChangesAsync();
                }

                foreach (var assignment in request.WorkersToAssign)
                {
                    var newWorkerAssignment = new Domain.Models.Assignment
                    {
                        IdWorker = assignment.IdWorker,
                        IdOrder = newOrder.IdOrder,
                        OrderLeader = assignment.OrderLeader,
                        HoursWorked = assignment.HoursWorked,
                    };

                    await _context.Assignments.AddAsync(newWorkerAssignment);
                    await _context.SaveChangesAsync();
                }

                dbContextTransaction.Commit();
            }

            return new CreateOrderWithDataResponse();
        }
    }
}