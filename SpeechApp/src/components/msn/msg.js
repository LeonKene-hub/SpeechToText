import { MsgBody, MsgText } from "./Style"

export const MsgBallon = ({lado , texto = ""})=>{
    return(
        <MsgBody lado={lado}>
            <MsgText>
                {`${texto}`}
            </MsgText>
        </MsgBody>
    )
}