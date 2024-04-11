namespace EmployeeGraphql.API.Types.Authorization
{
    using EmployeeGraphql.API.Models;

    public class AuthPayload : ObjectType<AuthPayloadDto>
    {
        protected override void Configure(IObjectTypeDescriptor<AuthPayloadDto> descriptor)
        {
                        descriptor.Field(e => e.Token).Name("token");
                        descriptor.Field(e => e.Success).Name("success");
                        descriptor.Field(e => e.Errors).Name("errors");

        }
    }

}