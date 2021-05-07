using BLL.Contracts;
using Common.Shared;
using DAL.DataModel;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BLL
{
    public class Clients : IClients
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IAddressInformationRepository _addressInformationRepository;
        private readonly IContactInformationRepository _contactInformationRepository;

        public Clients(IClientsRepository clientsRepository, IAddressInformationRepository addressInformationRepository, IContactInformationRepository contactInformationRepository)
        {
            _clientsRepository = clientsRepository;
            _addressInformationRepository = addressInformationRepository;
            _contactInformationRepository = contactInformationRepository;
        }

        public long AddClient(ClientDTO model)
        {
            long clientId = 0;
            Dictionary<string, object> clientParameters = new Dictionary<string, object>();
            clientParameters.Add("name", model.Name);
            clientParameters.Add("surname", model.Surname);
            clientParameters.Add("idnumber", model.IDNumber);
            clientParameters.Add("gender", model.Gender);
            clientParameters.Add("createdDate", DateTime.Now);

            clientId = _clientsRepository.AddClient(clientParameters);

            foreach (AddressInformationDTO address in model.AddressInformation)
            {
                Dictionary<string, object> addressParameters = new Dictionary<string, object>();
                addressParameters.Add("clients_Id", clientId);
                addressParameters.Add("addressLine1", address.AddressLine1);
                addressParameters.Add("addressLine2", address.AddressLine2);
                addressParameters.Add("addressLine3", address.AddressLine3);
                addressParameters.Add("type", address.Type);
                addressParameters.Add("postalCode", address.PostalCode);
                _addressInformationRepository.AddAddressInformation(addressParameters);
            }

            foreach (ContactInformationDTO contact in model.ContactInformation)
            {
                Dictionary<string, object> contactParameters = new Dictionary<string, object>();
                contactParameters.Add("clients_Id", clientId);
                contactParameters.Add("type", contact.Type);
                contactParameters.Add("contactAddress", contact.ContactAddress);
                _contactInformationRepository.AddContactInformation(contactParameters);
            }

            return clientId;
        }

        public void DeleteClient(ClientDTO model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", model.Id);

            _clientsRepository.DeleteClient(parameters);
        }

        public void EditClient(ClientDTO model)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", model.Id);
            parameters.Add("name", model.Name);
            parameters.Add("surname", model.Surname);
            parameters.Add("idnumber", model.IDNumber);
            parameters.Add("gender", model.Gender);

            _clientsRepository.EditClient(parameters);
        }        

        public PagedClientDTO GetClients(ClientDTO model, int pageIndex, int pageSize)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("name", model.Name);
            parameters.Add("surname", model.Surname);
            parameters.Add("idnumber", model.IDNumber);
            parameters.Add("gender", model.Gender);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);

            PageResult clientResult = _clientsRepository.GetClients(parameters);
            PagedClientDTO pagedModel = new PagedClientDTO(clientResult.totalCount);

            foreach (Client client in clientResult.listItems)
            {
                pagedModel.clients.Add(new ClientDTO() { 
                    Id = client.Id,
                    Name = client.Name,
                    Surname = client.Surname,
                    IDNumber = client.IDNumber,
                    Gender = client.Gender,
                    CreatedDate = client.CreatedDate
                });
            }

            return pagedModel;
        }

        public ClientDTO GetClient(long id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", id);

            PageResult result = _clientsRepository.GetClient(parameters);

            List<AddressInformationDTO> addressList = new List<AddressInformationDTO>();
            var AddressInformationList = _addressInformationRepository.GetAddressInformation(parameters).listItems;

            foreach (var item in AddressInformationList)
            {
                addressList.Add(new AddressInformationDTO() {
                    Id = item.Id,
                    Clients_Id = item.Clients_Id,
                    AddressLine1 = item.AddressLine1,
                    AddressLine2 = item.AddressLine2,
                    AddressLine3 = item.AddressLine3,                    
                    PostalCode = item.PostalCode,
                    Type = item.Type
                });
            }

            List<ContactInformationDTO> contactList = new List<ContactInformationDTO>();
            var ContactInformationList = _contactInformationRepository.GetContactInformation(parameters).listItems;

            foreach (var item in ContactInformationList)
            {
                contactList.Add(new ContactInformationDTO() {
                    Id = item.Id,
                    Clients_Id = item.Clients_Id,
                    ContactAddress = item.ContactAddress,
                    Type = item.Type
                });
            }
            
            return new ClientDTO()
            {
                Id = result.listItems[0].Id,
                Name = result.listItems[0].Name,
                Surname = result.listItems[0].Surname,
                IDNumber = result.listItems[0].IDNumber,
                CreatedDate = result.listItems[0].CreatedDate,
                Gender = result.listItems[0].Gender,
                AddressInformation = addressList,
                ContactInformation = contactList
            };
        }

        public byte[] ExportClients()
        {
            List<ClientReportDTO> datalist = new List<ClientReportDTO>();

            foreach (var item in _clientsRepository.ExportClients().listItems)
            {
                datalist.Add(new ClientReportDTO() {
                    Name = item.Name,
                    Surname = item.Surname,
                    IDNumber = item.IDNumber,
                    CreatedDate = item.CreatedDate,
                    Gender = item.Gender,
                    Address_Type = item.Address_Type,
                    AddressLine1 = item.AddressLine1,
                    AddressLine2 = item.AddressLine2,
                    AddressLine3 = item.AddressLine3,
                    PostalCode = item.PostalCode,
                    Contact_Type = item.Contact_Type,
                    ContactAddress = item.ContactAddress
                });
            }

            var csvData = new StringBuilder();

            csvData.AppendLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", "Name", "Surname", "IDNumber", "CreatedDate", "Gender", "Address_Type", "AddressLine1", "AddressLine2", "AddressLine3", "PostalCode", "Contact_Type", "ContactAddress"));

            foreach (ClientReportDTO item in datalist)
            {
                csvData.AppendLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", 
                    item.Name, item.Surname, item.IDNumber, item.CreatedDate, item.Gender, item.Address_Type, item.AddressLine1, item.AddressLine2, item.AddressLine3, item.PostalCode, item.Contact_Type, item.ContactAddress));                
            }

            return ASCIIEncoding.ASCII.GetBytes(csvData.ToString()); 
        }
    }
}
