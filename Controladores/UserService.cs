using AccesoDatos;
using DigitosVerificadoresLib.interfaces;
using Model;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class UserService : IDVService
    {
        PermissionsService permissionsService;
        //LanguageService languageService;

        UserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
            permissionsService = new PermissionsService();
            //languageService = new LanguageService();
        }
        public bool delete(string Nick) {
            return userRepository.delete(Nick);
        }
        public List<UserModel> GetAll()
        {
            List<UserModel> users = userRepository.getAll();
            //users.ForEach(user => user.Language = languageService.GetLanguage(user.Language.ID));
            return users;
        }
        public UserModel Get(String nic)
        {
            return userRepository.get(nic);
        }
        public UserModel Get(int id)
        {
            return userRepository.get(id);
        }

        public UserModel getByDni(int dni)
        {
            return userRepository.getByDni(dni);
        }
        public void SavePermissions(UserModel user)
        {
            userRepository.savePermissions(user);
        }
        public void ResetPassword(UserModel user)
        {
            string oldPassword = user.Password;
            try
            {
                string nonHashedPassword = Security.RandomString(10);
                user.Password = Security.HashSha256(nonHashedPassword);
                userRepository.updatePassword(user);
            }
            catch (Exception)
            {
                try
                {
                    user.Password = oldPassword;
                    userRepository.updatePassword(user);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public void CreateUser(UserModel user)
        {
            try
            {
                user.Permissions.Add(permissionsService.GetPatent(PermissionsEnum.Default));
                user.Password = Security.HashSha256(user.Password);
                userRepository.save(user);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateUser(UserModel user)
        {
            return userRepository.update(user);
        }
        public void AddTries(UserModel user)
        {
            UserModel toUpdate = Get(user.Nickname);
            toUpdate.Tries += 1;
            UpdateUser(toUpdate);
        }
        public void ResetTries(UserModel user)
        {
            UserModel toUpdate = Get(user.Nickname);
            toUpdate.Tries = 0;
            UpdateUser(toUpdate);
        }
        public void BlockUser(UserModel user)
        {
            UserModel toUpdate = Get(user.Nickname);
            toUpdate.Blocked = true;
            UpdateUser(toUpdate);
        }
        public void UnblockUser(UserModel user)
        {
            UserModel toUpdate = Get(user.Nickname);
            toUpdate.Blocked = false;
            toUpdate.Tries = 0;
            UpdateUser(toUpdate);
        }
        public void ChangePassword(string pass, string newPass, UserModel user)
        {
            if (Security.HashSha256(pass) == user?.Password)
            {
                string oldPassword = user.Password;
                try
                {
                    string nonHashedPassword = newPass;
                    user.Password = Security.HashSha256(nonHashedPassword);
                    userRepository.updatePassword(user);

                    StringBuilder sb = new StringBuilder();
                    sb.Append("Hola, ");
                    sb.Append(user.Name);
                    sb.AppendLine("Su contraseña fue actualizada: ");
                    sb.AppendLine(nonHashedPassword);

                    //MailService.SendMail(sb.ToString(), user.Mail);
                }
                catch (Exception)
                {
                    try
                    {
                        user.Password = oldPassword;
                        userRepository.updatePassword(user);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

        }
        public List<String> checkintegrity()
        {
            List<String> errors = new List<string>();
            List<UserModel> list = userRepository.getAll();

            list.ForEach(item =>
            {
                if (!item.dvh.Equals(userRepository.calculateDVH(item)))
                {
                    errors.Add($"En la tabla Usuarios: El Usuario con id : {item.Id} , fue modificado");
                }
            });

            if (!userRepository.calculateDVV(list).Equals(userRepository.getDVV()))
            {
                errors.Add($"El digito verificador vertical de la tabla usuarios no es correcto");
            }

            return errors;
        }
        public void reacalcDV()
        {
            userRepository.UpdateAllDV();
            userRepository.updateDVV();
        }
    }
}