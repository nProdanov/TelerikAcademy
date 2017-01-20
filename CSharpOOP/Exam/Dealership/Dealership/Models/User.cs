namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Common;
    using Common.Enums;
    using Contracts;

    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string password;
        private Role role;
        private string userName;
        private IList<IVehicle> vehicles;

        public User(string username, string firstName, string lastName, string password, string role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.vehicles = new List<IVehicle>();

            Validator.ValidateNull(role, "role cannot be null!");

            switch (role)
            {
                case "Admin":
                    this.role = Role.Admin;
                    break;
                case "VIP":
                    this.role = Role.VIP;
                    break;
                case "Normal":
                    this.role = Role.Normal;
                    break;
                default:
                    throw new ArgumentException("Invalid role!");
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                Validator.ValidateNull(
                    value,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Firstname", Constants.MinNameLength, Constants.MaxNameLength));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Firstname", Constants.MinNameLength, Constants.MaxNameLength));

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                Validator.ValidateNull
                    (value,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Lastname", Constants.MinNameLength, Constants.MaxNameLength));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Lastname", Constants.MinNameLength, Constants.MaxNameLength));

                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            private set
            {
                Validator.ValidateNull(
                    value,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Password", Constants.MinPasswordLength, Constants.MaxPasswordLength));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinPasswordLength,
                    Constants.MaxPasswordLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Password", Constants.MinPasswordLength, Constants.MaxPasswordLength));
                Validator.ValidateSymbols(
                    value,
                    Constants.PasswordPattern,
                    string.Format(Constants.InvalidSymbols, "Password"));

                this.password = value;
            }
        }

        public Role Role
        {
            get
            {
                return this.role;
            }
        }

        public string Username
        {
            get
            {
                return this.userName;
            }
            private set
            {
                Validator.ValidateNull(
                    value,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Username", Constants.MinNameLength, Constants.MaxNameLength));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Username", Constants.MinNameLength, Constants.MaxNameLength));
                Validator.ValidateSymbols(value, Constants.UsernamePattern, string.Format(Constants.InvalidSymbols, "Username"));

                this.userName = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return new List<IVehicle>(this.vehicles);
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            Validator.ValidateNull(commentToAdd, Constants.CommentCannotBeNull);
            Validator.ValidateNull(vehicleToAddComment, Constants.VehicleCannotBeNull);
            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);

            if (this.Role == Role.Admin)
            {
                throw new ArgumentException(Constants.AdminCannotAddVehicles);
            }

            if (this.Role == Role.Normal && this.Vehicles.Count >= 5)
            {
                throw new ArgumentException(string.Format(Constants.NotAnVipUserVehiclesAdd, this.Vehicles.Count));
            }

            this.vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            var strToPrint = new StringBuilder();
            strToPrint.AppendLine(string.Format("--USER {0}--", this.Username));

            if (this.Vehicles.Count == 0)
            {
                strToPrint.Append("--NO VEHICLES--");
                return strToPrint.ToString();
            }
            
            int countVehicle = 1;

            foreach (var vehicle in this.Vehicles)
            {
                strToPrint.AppendLine(string.Format("{0}. {1}", countVehicle, vehicle.ToString()));
                countVehicle++;
            }

            return strToPrint.ToString().TrimEnd();

        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            Validator.ValidateNull(commentToRemove, Constants.CommentCannotBeNull);
            Validator.ValidateNull(vehicleToRemoveComment, Constants.VehicleCannotBeNull);
            
            if(this.Username != commentToRemove.Author)
            {
                throw new ArgumentException("You are not the author!");
            }
            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);
            this.vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            return string.Format("Username: {0}, FullName: {1} {2}, Role: {3}", this.Username, this.firstName, this.LastName, this.Role);
        }
    }
}
