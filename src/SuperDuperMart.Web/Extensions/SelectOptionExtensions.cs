namespace SuperDuperMart.Web.Extensions
{
    public static class SelectOptionExtensions
    {
        /// <summary>
        /// Map RoleDto to SelectOption with 'Name' as text and 'Id' as value.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<SelectOption> ToSelectOptionList(this IEnumerable<RoleDto> dtos)
        {
            ArgumentNullException.ThrowIfNull(dtos);

            return dtos
                .Select(d => new SelectOption(d.Name, d.Id.ToString()))
                .ToList();
        }
    }
}
