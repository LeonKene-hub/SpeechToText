import { Ionicons } from '@expo/vector-icons';
import { FontAwesome } from '@expo/vector-icons';
import { FormContainer, FormBody, FormButton } from "./Style"

export const InputMsg = ({
    tipo = "audio",
    onPress,
    value,
    onChangeText
}) => {
    return (
        <FormContainer>
            <FormBody 
                placeholder="Digite seu texto aqui..."
                value={value}
                onChangeText={onChangeText}
            />
            <FormButton onPress={onPress}>
                {tipo == "audio" ?
                    <FontAwesome name="microphone" size={24} color="black" />
                    :
                    <Ionicons name="send-sharp" size={24} color="black" />
                }
            </FormButton>
        </FormContainer>
    )
}