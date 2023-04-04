using Reservoom.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
    {
    public class ReservationBook
        {
        private readonly List<Reservation> _reservations;

        /// <summary>
        /// Make a Reservation list.
        /// </summary>
        public ReservationBook()
            {
            _reservations = new List<Reservation>();
            }

        /// <summary>
        /// Get the reservation for the user.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>The reservations for the user.</returns>
        public IEnumerable<Reservation> GetReservationsForUser(string userName)
            {
            return _reservations.Where(r => r.UserName == userName);
            }

        /// <summary>
        /// Add reservations
        /// </summary>
        /// <param name="reservation"></param>
        /// <exception cref="ReservationConflictException"></exception>
        public void AddReservation(Reservation reservation)
            {
            foreach (Reservation existingReservation in _reservations)
                {
                if(existingReservation.Conflicts(reservation))
                    {
                    throw new ReservationConflictException(existingReservation, reservation);
                    }
                }
            _reservations.Add(reservation);
            }
        }
    }
