using AccesoDatos;
using Model;
using Modelos;
using System.Collections.Generic;
using Component = Modelos.Component;

namespace Servicios
{
    public class PermissionsService
    {
        private PermissionRepository permissionsRepository;
        public PermissionsService()
        {
            permissionsRepository = new PermissionRepository();
        }
        public bool Contains(Component component, Component includes)
        {
            bool exist = false;
            if (component.Id.Equals(includes.Id))
            {
                exist = true;
            }
            else
            {
                foreach (Component item in component.Childs)
                {
                    if (Contains(item, includes)) return true;
                }
            }
            return exist;
        }
        public List<PermissionsEnum> GetAllPermission()
        {
            return permissionsRepository.GetAllPermission();
        }
        public Component SaveComponent(Component component, bool isFamily)
        {
            return permissionsRepository.GuardarComponente(component, isFamily);
        }
        public void SaveFamily(Family family)
        {
            permissionsRepository.SaveFamily(family);
        }
        public List<Patent> GetAllPatentes()
        {
            return permissionsRepository.GetAllPatents();
        }
        public List<Family> GetAllFamilies()
        {
            return permissionsRepository.GetAllFamilies();
        }
        public List<Component> GetAll(string familia)
        {
            return permissionsRepository.GetAll(familia);

        }
        public void FillUserComponents(UserModel u)
        {
            permissionsRepository.FillUserComponents(u);

        }
        public void FillFamilyComponents(Family familia)
        {
            permissionsRepository.FillFamilyComponents(familia);
        }
        //public Patent GetPatent(PermissionRepository permissionsEnum)
        //{
        //    return permissionsRepository.GetPatent(permissionsEnum); //Y esta flasheada?
        //}
        public Patent GetPatent(PermissionsEnum permissionsEnum)
        {
            //Este lo agregue nuevo porque el otro era de drogadicto
            return permissionsRepository.GetPatent(permissionsEnum);
        }
    }
}
