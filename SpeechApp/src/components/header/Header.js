import { HeaderBody, HeaderImage, Identify, Name, Status } from "./Style"

export const HeaderMsn = () => {

    return (
        <HeaderBody>
            <HeaderImage source={require("../imgs/Rectangle.png")}/>

            <Identify>
                <Name>CodingDojo</Name>
                <Status>digitando</Status>

            </Identify>

        </HeaderBody>
    )

}